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

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public class OcjeneService : BaseCRUDService<Model.Ocjene, OcjeneSearchRequest, OcjeneUpsertRequest, OcjeneUpsertRequest, Database.Ocjene>
    {

        public OcjeneService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.Ocjene> GetAll(OcjeneSearchRequest search = default)
        {
            var query = _context.Ocjenes
                .Include(i=>i.Pacijent)
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
            if (search?.MjesecOcjene != 0)
            {
                query = query.Where(x => x.Kreirano.Month == search.MjesecOcjene);
            }
            if (search?.GodinaOcjene != 0)
            {
                query = query.Where(x => x.Kreirano.Year == search.GodinaOcjene);
            }
            if (search?.Ocjena != 0)
            {
                query = query.Where(x => x.Ocjena == search.Ocjena);
            }
            if (search?.MjesecOcjene != 0)
            {
                query = query.Where(x => x.Kreirano.Month == search.MjesecOcjene);
            }
            if (!string.IsNullOrWhiteSpace(search?.Komentar))
            {
                query = query.Where(x => x.Komentar.ToLower().Contains(search.Komentar.ToLower()));
            }
            var entities = query.ToList();
            var result = _mapper.Map<List<Model.Ocjene>>(entities);
            return result;
        }

        public override Model.Ocjene Insert(OcjeneUpsertRequest request)
        {
            var ocjena = _context.Ocjenes.FirstOrDefault(i =>
                i.PacijentId == request.PacijentId && i.UslugaId == request.UslugaId);
            if (ocjena != null)
            {
                throw new UserException("Vec ste unijeli ocjenu za ovu uslugu!");
            }
            var entity = _mapper.Map<Database.Ocjene>(request);

            if (request.Ocjena > 10 || request.Ocjena < 1) 
            {
                throw new UserException("Ocjena mora biti od 1 do 10!");
            }

            _context.Add(entity);
            entity.Kreirano = DateTime.Now;

            _context.SaveChanges();

            return _mapper.Map<Model.Ocjene>(entity);
        }
        public override Model.Ocjene Update(int id, OcjeneUpsertRequest request)
        {
            var entity = _context.Ocjenes.Find(id);
            if (request.Ocjena > 10 || request.Ocjena < 1) 
            {
                throw new UserException("Ocjena mora biti od 1 do 10!");
            }

            _mapper.Map(request, entity);
            entity.Kreirano = DateTime.Now;
            _context.SaveChanges();

            return _mapper.Map<Model.Ocjene>(entity);
        }
    }
}
