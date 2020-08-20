using AutoMapper;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Filters;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using StomatoloskaOrdinacija.WebAPI.Helper;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;
using Korisnici = StomatoloskaOrdinacija.Model.Korisnici;

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public class KorisniciService : BaseCRUDService<Model.Korisnici, KorisniciSearchRequest, KorisniciInsertRequest, KorisniciUpdateRequest, Database.Korisnici>, IKorisniciService
    {
        protected IConfiguration _configuration;
        public KorisniciService(MyContext context, IMapper mapper, IConfiguration configuration) : base(context, mapper)
        {
            _configuration = configuration;
        }


        public Model.Korisnici Login(KorisniciLoginRequest request)
        {
            var entity = _context.Korisnici
                .Include(i=>i.Uloga)
                .Include(i=>i.Grad)
                .Include(i=>i.Grad.Drzava)
                .FirstOrDefault(x => x.KorisnickoIme == request.Username);

            if (entity == null)
            {
                throw new UserException("Pogrešan username!");
            }

            var hash = GenerateHash(entity.LozinkaSalt, request.Password);

            if (hash != entity.LozinkaHash)
            {
                throw new UserException("Pogrešan password!");
            }

            return _mapper.Map<Model.Korisnici>(entity);
        }
        
        #region MobileApp
        public Model.Korisnici LoginMobile(KorisniciLoginRequest request)
        {
            var user = _context.Korisnici.FirstOrDefault(x => x.KorisnickoIme == request.Username);

            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, request.Password);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnici>(user);
                }
            }

            return null;
        }
        #endregion

        public Model.Korisnici Registracija(KorisniciRegistracijaRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);
            
            if (request.Password != request.PasswordPotvrda)
            {
                throw new UserException("Password i potvrda se ne slažu!");
            }

            var korisnici = _context.Korisnici.ToList();
            foreach (var korisnik in korisnici)
            {
                if(korisnik.KorisnickoIme == request.KorisnickoIme)
                    throw new UserException("Korisnicko ime koje ste unijeli je zauzeto!");
                if(korisnik.Email == request.Email)
                    throw new UserException("Email koji ste unijeli je zauzet!");
            }

            _context.Add(entity);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            entity.Kreirano = DateTime.Now;
            
            if(request.Slika == null)//registracija preko mobitela
            {
                var noimgpath = new DirectoryInfo(Environment.CurrentDirectory).FullName;
                noimgpath = noimgpath + "\\no_image.jpeg";
                var file = File.ReadAllBytes(noimgpath);
                entity.Slika = file;
            }

            //pacijent uloga ID = 4
            entity.UlogaId = 4;
            _context.SaveChanges();

            var noviPacijent = new Database.Pacijent
            {
                AlergijaNaLijek = request.AlergijaNaLijek,
                Aparatic = request.Aparatic,
                KorisnikId = entity.KorisnikId,
                Navlake = request.Navlake,
                Proteza = request.Proteza,
                Terapija = request.Terapija
            };
            _context.Pacijents.Add(noviPacijent);
            _context.SaveChanges();
            
            
            return _mapper.Map<Model.Korisnici>(entity);
        }

        public override IList<Model.Korisnici> GetAll(KorisniciSearchRequest search)
        {
            var query = _context.Korisnici
                .Include(i=>i.Grad)
                .Include(i=>i.Grad.Drzava)
                .Include(i=>i.Uloga)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.PrezimeFilter))
            {
                query = query.Where(x => x.Prezime == search.PrezimeFilter);
            }

            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                query = query.Where(x => x.Email == search.Email);
            }

            if (!string.IsNullOrWhiteSpace(search?.JMBG))
            {
                query = query.Where(x => x.JMBG == search.JMBG);
            }

            if (!string.IsNullOrWhiteSpace(search?.Grad))
            {
                query = query.Where(x => x.Grad.Naziv == search.Grad);
            }

            if (!string.IsNullOrWhiteSpace(search?.Drzava))
            {
                query = query.Where(x => x.Grad.Drzava.Naziv == search.Drzava);
            }
            
            var entities = query.ToList();
            
            var result = _mapper.Map<IList<Model.Korisnici>>(entities);
            

            return result;
        }
        public IList<Model.Korisnici> GetAllDatumOdDo(KorisniciSearchRequest search = default)
        {
            var korisnici = _context.Korisnici.Where(i=>i.UlogaId == 4).ToList();

            var novalista = new List<Database.Korisnici>();
            foreach (var korisnik in korisnici)
            {
                if (korisnik.Kreirano > search.OD && korisnik.Kreirano < search.DO)
                {
                    novalista.Add(korisnik);
                }
            }
            
            var result = _mapper.Map<IList<Model.Korisnici>>(novalista);
            
            return result;
        }

        public override Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);
            
            if (request.Password != request.PasswordPotvrda)
            {
                throw new UserException("Password i potvrda se ne slažu!");
            }

            var korisnici = _context.Korisnici.ToList();
            foreach (var korisnik in korisnici)
            {
                if(korisnik.KorisnickoIme == request.KorisnickoIme)
                    throw new UserException("Korisnicko ime koje ste unijeli je zauzeto!");
                if(korisnik.Email == request.Email)
                    throw new UserException("Email koji ste unijeli je zauzet!");
            }

            _context.Add(entity);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            entity.Kreirano = DateTime.Now;
            _context.SaveChanges();
            //Tu dodati provjeru za pacijenta
            var temp = _context.Uloges.FirstOrDefault(i => i.UlogaId == entity.UlogaId);
            if (temp != null && temp.Naziv == "Pacijent")
            {
                var noviPacijent = new Database.Pacijent
                {
                    AlergijaNaLijek = false,
                    Aparatic = false,
                    KorisnikId = entity.KorisnikId,
                    Navlake = false,
                    Proteza = false,
                    Terapija = false
                };
                _context.Pacijents.Add(noviPacijent);
                _context.SaveChanges();
            }
            
            return _mapper.Map<Model.Korisnici>(entity);
        }

        public override Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            var entity = _context.Korisnici.Find(id);
            var exSlika=request.Slika;
            if (request.Slika == null)
            {
                exSlika = entity.Slika;

            }



            _mapper.Map(request, entity);
            entity.Slika = exSlika;
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirm)
                {
                    throw new UserException("Password i potvrda se ne slažu!");
                }
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }
            
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public IList<Model.Pacijent> GetAllPacijenti(KorisniciSearchRequest search = default)
        {
            var query = _context.Pacijents
                .Include(i=>i.Korisnici)
                .Include(i=>i.Korisnici.Grad)
                .Include(i=>i.Korisnici.Grad.Drzava)
                .Include(i=>i.Korisnici.Uloga)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Korisnici.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.PrezimeFilter))
            {
                query = query.Where(x => x.Korisnici.Prezime == search.PrezimeFilter);
            }

            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                query = query.Where(x => x.Korisnici.Email == search.Email);
            }

            if (!string.IsNullOrWhiteSpace(search?.JMBG))
            {
                query = query.Where(x => x.Korisnici.JMBG == search.JMBG);
            }

            if (!string.IsNullOrWhiteSpace(search?.Grad))
            {
                query = query.Where(x => x.Korisnici.Grad.Naziv == search.Grad);
            }

            if (!string.IsNullOrWhiteSpace(search?.Drzava))
            {
                query = query.Where(x => x.Korisnici.Grad.Drzava.Naziv == search.Drzava);
            }
            
            var entities = query.ToList();
            
            var result = _mapper.Map<IList<Model.Pacijent>>(entities);
            

            return result;
        }

        public IList<Model.KorisnikPacijent> GetAllKorisnikPacijenti(KorisniciSearchRequest search = default)
        {
            var pacijenti = _context.Korisnici
                .Include(i=>i.Grad)
                .Include(i=>i.Grad.Drzava)
                .Include(i=>i.Uloga)
                .Where(i=>i.UlogaId == 4)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                pacijenti = pacijenti.Where(x => x.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.PrezimeFilter))
            {
                pacijenti = pacijenti.Where(x => x.Prezime == search.PrezimeFilter);
            }

            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                pacijenti = pacijenti.Where(x => x.Email == search.Email);
            }

            if (!string.IsNullOrWhiteSpace(search?.JMBG))
            {
                pacijenti = pacijenti.Where(x => x.JMBG == search.JMBG);
            }

            if (!string.IsNullOrWhiteSpace(search?.Grad))
            {
                pacijenti = pacijenti.Where(x => x.Grad.Naziv == search.Grad);
            }

            if (!string.IsNullOrWhiteSpace(search?.Drzava))
            {
                pacijenti = pacijenti.Where(x => x.Grad.Drzava.Naziv == search.Drzava);
            }
            
            var entities = pacijenti.ToList();
            //nisu ubaceni podaci od pacijenta, samo od korisnika-pacijenta
            var result = _mapper.Map<IList<Model.KorisnikPacijent>>(entities);
            

            return result;
        }
        public Model.Pacijent Update(int id, KorisniciPacijentUpdateRequest request)
        {
            var korisnik = _context.Korisnici.Find(id);
            var pacijent = _context.Pacijents.FirstOrDefault(i => i.KorisnikId == korisnik.KorisnikId);

            var exSlika=request.Slika;
            if (request.Slika == null)
            {
                exSlika = korisnik.Slika;

            }


            //update tabelu korisnik
            _mapper.Map(request, korisnik);
            //update tabelu pacijent
            _mapper.Map(request, pacijent);
            korisnik.Slika = exSlika;
            if (request.Password != request.PasswordConfirm)
            {
                throw new UserException("Password i potvrda se ne slažu!");
            }
            korisnik.LozinkaSalt = GenerateSalt();
            korisnik.LozinkaHash = GenerateHash(korisnik.LozinkaSalt, request.Password);

            _context.SaveChanges();

            return _mapper.Map<Model.Pacijent>(pacijent);

        }

        public Model.KorisnikPacijent GetByIdKorisnikPacijent(int id)
        {
            var entity = _context.Korisnici.Find(id);
            var specpodaci = _context.Pacijents.FirstOrDefault(i => i.KorisnikId == entity.KorisnikId);
            
            var result = _mapper.Map<Model.KorisnikPacijent>(entity);
            _mapper.Map(specpodaci, result);
            return result;
        }

        public Model.KorisnikPacijent UpdateKorisniciPacijent(int id, KorisniciPacijentUpdateRequest request)
        {
            var korisnik = _context.Korisnici.Find(id);
            var pacijent = _context.Pacijents.FirstOrDefault(i => i.KorisnikId == korisnik.KorisnikId);

            var exSlika=request.Slika;
            if (request.Slika == null)
            {
                exSlika = korisnik.Slika;

            }

            //update tabelu korisnik
            _mapper.Map(request, korisnik);
            //update tabelu pacijent
            _mapper.Map(request, pacijent);
            korisnik.Slika = exSlika;
            if (request.Password != request.PasswordConfirm)
            {
                throw new UserException("Password i potvrda se ne slažu!");
            }

            if (request.Password != null)
            {
                korisnik.LozinkaSalt = GenerateSalt();
                korisnik.LozinkaHash = GenerateHash(korisnik.LozinkaSalt, request.Password);
            }

            _context.SaveChanges();

            return _mapper.Map<Model.KorisnikPacijent>(korisnik);
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


        public Model.Korisnici GetNajboljiStomatolog()
        {
            var korisnici = _context.Korisnici.Where(i=>i.UlogaId == 2 || i.UlogaId == 1).ToList();
            var brojac = 0;
            var noviKorisnik = new Database.Korisnici();
            foreach (var korisnik in korisnici)
            {
                var pregledi = _context.Pregleds.Count(i => i.KorisnikId == korisnik.KorisnikId);
                if (pregledi > brojac)
                {
                    brojac = pregledi;
                    noviKorisnik = korisnik;
                }
            }
            var tempMap = _mapper.Map<Model.Korisnici>(noviKorisnik);
            tempMap.obavljenoPregleda = brojac;
            return tempMap;
        }
        public Model.Korisnici GetNajboljeOsoblje()
        {
            var korisnici = _context.Korisnici.Where(i=>i.UlogaId == 3 || i.UlogaId == 1).ToList();
            var brojac = 0;
            var noviKorisnik = new Database.Korisnici();
            foreach (var korisnik in korisnici)
            {
                var ulazakuSkladiste = _context.UlazUSkladistes.Count(i => i.KorisnikId == korisnik.KorisnikId);
                if (ulazakuSkladiste > brojac)
                {
                    brojac = ulazakuSkladiste;
                    noviKorisnik = korisnik;
                }
            }
            var tempMap = _mapper.Map<Model.Korisnici>(noviKorisnik);
            tempMap.obavljenoPregleda = brojac;
            return tempMap;
        }

        public Model.Korisnici GetNajBoljiPacijent()
        {
            var pacijenti = _context.Pacijents.ToList();
            decimal suma = 0;
            var noviKorisnik = 0;
            foreach (var pacijent in pacijenti)
            {
                var racun = _context.Racuns.Where(i => i.Pregled.Termin.Pacijent.PacijentId == pacijent.PacijentId);
                decimal temp = racun.Sum(i=>i.UkupnaCijena);
                if (temp > suma)
                {
                    suma = temp;
                    noviKorisnik = pacijent.KorisnikId;
                }
            }

            var finalkorisnik = _context.Korisnici.Find(noviKorisnik);
            var tempMap = _mapper.Map<Model.Korisnici>(finalkorisnik);
            tempMap.UkupnoNovca = suma;
            return tempMap;
        }
        public IList<Model.Korisnici> TopPacijenti(KorisniciSearchRequest search = default)
        {
            var korisnici = _context.Korisnici.Where(i => i.UlogaId == 4).ToList();
            var novalista = new List<Model.Korisnici>();

            foreach (var korisnik in korisnici)
            {
                var test = _context.MedicinskiKartons.Where(i =>
                    i.Pacijent.Korisnici.KorisnikId == korisnik.KorisnikId);
                if (test.FirstOrDefault() != null)
                {
                    var noviKorisnik = _mapper.Map<Model.Korisnici>(korisnik);
                    noviKorisnik.obavljenoPregleda = test.Count();
                    novalista.Add(noviKorisnik);
                }
            }

            var temp = novalista.OrderByDescending(i => i.obavljenoPregleda).Take(10).ToList();
            return temp;

        }

    }
}
