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
    public class UlazUSkladisteService : BaseCRUDService<Model.UlazUSkladiste, UlazUSkladisteSearchRequest, UlazUSkladisteInsertRequest, UlazUSkladisteInsertRequest, Database.UlazUSkladiste>
    {

        public UlazUSkladisteService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.UlazUSkladiste> GetAll(UlazUSkladisteSearchRequest search = default)
        {
            var query = _context.UlazUSkladistes
                .Include(i=>i.Korisnici)
                .AsQueryable();

            if (search?.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }
            if (!string.IsNullOrWhiteSpace(search?.BrojFakture))
            {
                query = query.Where(x => x.BrojFakture == search.BrojFakture);
            }
            if (search?.Dan != 0)
            {
                query = query.Where(x => x.Datum.Day == search.Dan);
            }
            if (search?.Godina != 0)
            {
                query = query.Where(x => x.Datum.Year == search.Godina);
            }
            if (search?.Mjesec != 0)
            {
                query = query.Where(x => x.Datum.Month == search.Mjesec);
            }
            var entities = query.ToList();
            var result = _mapper.Map<List<Model.UlazUSkladiste>>(entities);
            return result;
        }

        public override Model.UlazUSkladiste Insert(UlazUSkladisteInsertRequest request)
        {
            var entity = _mapper.Map<Database.UlazUSkladiste>(request);
            var provjera = _context.UlazUSkladistes.FirstOrDefault(i => i.BrojFakture == entity.BrojFakture);
            if (provjera != null)
            {
                provjera.Datum = DateTime.Now;
                _context.SaveChanges();
                return _mapper.Map<Model.UlazUSkladiste>(provjera);
            }
            _context.Add(entity);
            entity.Datum = DateTime.Now;

            _context.SaveChanges();

            return _mapper.Map<Model.UlazUSkladiste>(entity);
        }
        public override Model.UlazUSkladiste Update(int id, UlazUSkladisteInsertRequest request)
        {
            var entity = _context.UlazUSkladistes.Find(id);

            _mapper.Map(request, entity);
            entity.Datum = DateTime.Now;
            _context.SaveChanges();

            return _mapper.Map<Model.UlazUSkladiste>(entity);
        }
    }
}
