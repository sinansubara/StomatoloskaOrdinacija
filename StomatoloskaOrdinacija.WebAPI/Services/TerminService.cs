using AutoMapper;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Filters;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;
using Termin = StomatoloskaOrdinacija.Model.Termin;

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public class TerminService : BaseCRUDService<Model.Termin, TerminSearchRequest, TerminInsertRequest, TerminInsertRequest, Database.Termin>
    {

        public TerminService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.Termin> GetAll(TerminSearchRequest search = default)
        {
            var query = _context.Termins
                .Include(i=>i.Pacijent.Korisnici)
                .Include(i=>i.Usluga)
                .AsQueryable();

            if (search?.PacijentId != 0)
            {
                query = query.Where(x => x.Pacijent.PacijentId == search.PacijentId);
            }
            if (search?.UslugaId != 0)
            {
                query = query.Where(x => x.Usluga.UslugaId == search.UslugaId);
            }
            if (search?.Mjesec != 0)
            {
                query = query.Where(x => x.DatumVrijeme.Month == search.Mjesec);
            }
            if (search?.Godina != 0)
            {
                query = query.Where(x => x.DatumVrijeme.Year == search.Godina);
            }
            if (search?.IsNaCekanju == true)
            {
                query = query.Where(x => x.IsNaCekanju == search.IsNaCekanju);
            }
            if (search?.IsOdobren == "Da")
            {
                query = query.Where(x => x.IsOdobren == true);
            }
            if (search?.IsOdobren == "Ne")
            {
                query = query.Where(x => x.IsOdobren == false);
            }

            if (search?.IsOdbijenMobile == "Da")
            {
                query = query.Where(x => x.IsNaCekanju == false && x.IsOdobren == false);
            }
            var entities = query.OrderByDescending(i=>i.DatumVrijeme).ToList();
            var NovaLista = new List<Database.Termin>();
            if (search.IsIskoristenRequest == "Da")
            {
                foreach (var entity in entities)
                {
                    var flag = _context.Pregleds.FirstOrDefault(i => i.TerminId == entity.TerminId);
                    if (flag != null)
                    {
                        NovaLista.Add(entity);
                    }
                }
                var result = _mapper.Map<List<Model.Termin>>(NovaLista);
                foreach (var convert in result)
                {
                    convert.UslugaIme = "Usluga: " + convert.Usluga.Naziv + "    |    Pacijent: " + convert.Pacijent.Korisnici.Ime + " " +
                                        convert.Pacijent.Korisnici.Prezime;
                }
                return result;

            }
            if (search.IsIskoristenRequest == "Ne")
            {
                foreach (var entity in entities)
                {
                    var flag = _context.Pregleds.FirstOrDefault(i => i.TerminId == entity.TerminId);
                    if (flag == null)
                    {
                        NovaLista.Add(entity);
                    }
                }
                var result = _mapper.Map<List<Model.Termin>>(NovaLista);
                foreach (var convert in result)
                {
                    convert.UslugaIme = "Usluga: " + convert.Usluga.Naziv + "    |    Pacijent: " + convert.Pacijent.Korisnici.Ime + " " +
                                        convert.Pacijent.Korisnici.Prezime;
                }
                return result;

            }

            var result2 = _mapper.Map<List<Model.Termin>>(entities);

            foreach (var convert in result2)
            {
                convert.UslugaIme = "Usluga: " + convert.Usluga.Naziv + "    |    Pacijent: " + convert.Pacijent.Korisnici.Ime + " " +
                                    convert.Pacijent.Korisnici.Prezime;
                convert.UslugaNaziv = convert.Usluga.Naziv;
                convert.PacijentIme = convert.Pacijent.Korisnici.Ime + " " +
                                      convert.Pacijent.Korisnici.Prezime;
            }



            return result2;
        }
        public override Model.Termin GetById(int id)
        {
            var entity = _context.Termins
                .Include(i => i.Pacijent)
                .Include(i=>i.Pacijent.Korisnici).Include(i=>i.Usluga).FirstOrDefault(i => i.TerminId == id);

            return _mapper.Map<Model.Termin>(entity);
        }


        public override Model.Termin Insert(TerminInsertRequest request)
        {
            var termin = _context.Termins.FirstOrDefault(i =>
                i.UslugaId == request.UslugaId && i.PacijentId == request.PacijentId &&
                i.DatumVrijeme.Year == request.DatumVrijeme.Year &&
                i.DatumVrijeme.Month == request.DatumVrijeme.Month && i.DatumVrijeme.Day == request.DatumVrijeme.Day);
            if (termin != null)
            {
                throw new UserException("Vec ste poslali zahtjev za termin, za odabranu uslugu i datum!");
            }
            var entity = _mapper.Map<Database.Termin>(request);
            
            _context.Add(entity);
            entity.IsNaCekanju = true;
            entity.IsOdobren = false;

            _context.SaveChanges();

            return _mapper.Map<Model.Termin>(entity);
        }
        public override Model.Termin Update(int id, TerminInsertRequest request)
        {
            var entity = _context.Termins.Find(id);

            _mapper.Map(request, entity);
            if (!entity.IsNaCekanju)
            {
                throw new UserException("Termin se ne moze mjenjat, jer je pregledan!");
            }
            _context.SaveChanges();

            return _mapper.Map<Model.Termin>(entity);
        }

    }
}
