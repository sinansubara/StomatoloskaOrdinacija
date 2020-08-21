using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Filters;
using StomatoloskaOrdinacija.WebAPI.Helper;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LozinkaController : ControllerBase
    {
        private static MyContext _context;
        protected IConfiguration _configuration;
        public LozinkaController(MyContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpGet]
        public Model.PromjenaLozinke ZaboravljenaLozinka([FromQuery]PromjenaLozinkeInsertRequest request)
        {
            var temp = _context.Korisnici.FirstOrDefault(i => i.Email == request.Email);
            if (temp == null)
            {
                throw new UserException("Email adresa ne postoji!");
            }

            var promjenaTemp = _context.PromjenaLozinkes.FirstOrDefault(i => i.KorisnikId == temp.KorisnikId);

            if (promjenaTemp != null)
            {
                if ((DateTime.Now - promjenaTemp.DatumPromjene).TotalHours < 24)
                {
                    var postojiPromjena = new Model.PromjenaLozinke
                    {
                        DatumPromjene = promjenaTemp.DatumPromjene,
                        KorisnikId = promjenaTemp.KorisnikId,
                        Vrijednost = promjenaTemp.Vrijednost,
                        PromjenaLozinkeID = promjenaTemp.PromjenaLozinkeID
                    };
                    return postojiPromjena;
                    
                }
                else
                {
                    _context.PromjenaLozinkes.Remove(promjenaTemp);
                    _context.SaveChanges();
                }
            }

            string primalacPoruke = "";

            primalacPoruke = temp.Ime + " " + temp.Prezime;
            string vrijednost = RandomString.GetString(6);

            string poruka = "Kako bi promjenili lozinku, morate upisati u svoju aplikaciju sljedeći niz karaktera:   " + vrijednost +
                            "\nOvaj kod za resetiranje lozinke, će biti aktivan samo 24 sata, a poslije toga će postati nevažeći.";

            try
            {
                EmailSettings.SendEmail(_configuration, primalacPoruke, temp.Email, "Promjena lozinke", poruka);
            }
            catch (Exception)
            {
                throw new UserException("Email servis ne radi, vjerovatno blokiran od strane gmaila!");
            }
            

            Database.PromjenaLozinke zahtjevZaPromjenomLozinke = new Database.PromjenaLozinke
            {
                Vrijednost = vrijednost,
                KorisnikId = temp.KorisnikId,
                DatumPromjene = DateTime.Now
            };
            _context.PromjenaLozinkes.Add(zahtjevZaPromjenomLozinke);
            _context.SaveChanges();

            var tempconvert = new Model.PromjenaLozinke
            {
                DatumPromjene = zahtjevZaPromjenomLozinke.DatumPromjene,
                KorisnikId = zahtjevZaPromjenomLozinke.KorisnikId,
                Vrijednost = zahtjevZaPromjenomLozinke.Vrijednost
            };


            return tempconvert;
        }

        [AllowAnonymous]
        [HttpGet("promjena")]
        public Model.PromjenaLozinke PromjeniLozinku([FromQuery]PromjenaLozinkeVrijednostInsertRequest request)
        {
            var korisnik = _context.Korisnici.FirstOrDefault(i => i.KorisnickoIme == request.KorisnickoIme);
            if (korisnik == null)
            {
                throw new UserException("Ne mozete promjeniti lozinku, jer korisnicko ime ne postoji!");
            }

            var vrijednostProvjera = _context.PromjenaLozinkes.FirstOrDefault(i =>
                i.KorisnikId == korisnik.KorisnikId && i.Vrijednost == request.Vrijednost);

            if (vrijednostProvjera == null)
            {
                throw new UserException("Niste unijeli ispravan kod za ovo korisnicko ime!");
            }

            if (string.IsNullOrWhiteSpace(request.Lozinka))
            {
                throw new UserException("Niste unijeli lozinku!");
            }

           
            if (request.Lozinka != request.PotvrdaLozinke)
            {
                throw new UserException("Password i potvrda se ne slažu!");
            }

            korisnik.LozinkaSalt = GenerateSalt();
            korisnik.LozinkaHash = GenerateHash(korisnik.LozinkaSalt, request.Lozinka);
            

            var tempconvert = new Model.PromjenaLozinke
            {
                DatumPromjene = vrijednostProvjera.DatumPromjene,
                KorisnikId = vrijednostProvjera.KorisnikId,
                Vrijednost = vrijednostProvjera.Vrijednost
            };
            _context.PromjenaLozinkes.Remove(vrijednostProvjera);
            _context.SaveChanges();

            
            return tempconvert;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}