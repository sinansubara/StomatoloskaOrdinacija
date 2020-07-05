using AutoMapper;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Filters;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public class PregledService : BaseCRUDService<Model.Pregled, PregledSearchRequest, PregledInsertRequest, PregledInsertRequest, Database.Pregled>
    {

        public PregledService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.Pregled> GetAll(PregledSearchRequest search = default)
        {
            var query = _context.Pregleds
                .Include(i=>i.Dijagnoza)
                .Include(i=>i.Termin)
                .Include(i=>i.Korisnici)
                .Include(i=>i.Lijek)
                .Include(i=>i.Skladiste)
                .AsQueryable();

            if (search?.KorisnikId != 0)
            {
                query = query.Where(x => x.Korisnici.KorisnikId == search.KorisnikId);
            }
            if (search?.TerminId != 0)
            {
                query = query.Where(x => x.Termin.TerminId == search.TerminId);
            }
            if (search?.SkladisteId != 0)
            {
                query = query.Where(x => x.Skladiste.SkladisteId == search.SkladisteId);
            }
            if (!string.IsNullOrWhiteSpace(search?.Napomena))
            {
                query = query.Where(x => x.Napomena.ToLower().Contains(search.Napomena.ToLower()));
            }
            var entities = query.ToList();
            var result = _mapper.Map<List<Model.Pregled>>(entities);
            return result;
        }

        public override Model.Pregled Insert(PregledInsertRequest request)
        {
            var provjera = _context.Termins.FirstOrDefault(i => i.TerminId == request.TerminId);
            if (provjera != null && !provjera.IsOdobren)
            {
                if (provjera.IsNaCekanju)
                {
                    provjera.IsOdobren = true;
                    provjera.IsNaCekanju = false;
                }
                else
                {
                    throw new UserException("Termin je odbijen!");
                }
                
            }

            var flag = _context.Pregleds.FirstOrDefault(i => i.TerminId == request.TerminId);
            if (flag != null)
                throw new UserException("Termin je vec iskoristen za neki drugi pregled!");

            var kolicinaNaSkladistu =
                _context.Skladistes.FirstOrDefault(i => i.SkladisteId == request.SkladisteId);

            if (kolicinaNaSkladistu != null && kolicinaNaSkladistu.Kolicina < request.KolicinaOdabranogMaterijala)
            {
                throw new UserException("Unijeli ste kolicinu materijala vecu nego sto ima na skladistu!");
            }
            if (kolicinaNaSkladistu != null && kolicinaNaSkladistu.Kolicina >= request.KolicinaOdabranogMaterijala)
            {
                kolicinaNaSkladistu.Kolicina = kolicinaNaSkladistu.Kolicina - request.KolicinaOdabranogMaterijala;
                _context.SaveChanges();
            }
            var noviRecordOpotrosnji = new Database.Materijali
            {
                Datum = DateTime.Now,
                Kolicina = request.KolicinaOdabranogMaterijala,
                Naziv = kolicinaNaSkladistu.Naziv,
                SkladisteId = request.SkladisteId
            };
            _context.Add(noviRecordOpotrosnji);
            var entity = _mapper.Map<Database.Pregled>(request);
            
            _context.Add(entity);

            _context.SaveChanges();

            var pacijent = _context.Termins.FirstOrDefault(i => i.TerminId == entity.TerminId).PacijentId;

            var medicinskiKarton = new Database.MedicinskiKarton
            {
                Datum = DateTime.Now,
                Napomena = entity.Napomena,
                PacijentId = pacijent,
                PregledId = entity.PregledId
            };
            _context.MedicinskiKartons.Add(medicinskiKarton);
            _context.SaveChanges();


            return _mapper.Map<Model.Pregled>(entity);
        }
    }
}
