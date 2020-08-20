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
    public class SkladisteService : BaseCRUDService<Model.Skladiste, SkladisteSearchRequest, SkladisteInsertRequest, SkladisteInsertRequest, Database.Skladiste>
    {

        public SkladisteService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.Skladiste> GetAll(SkladisteSearchRequest search = default)
        {
            var query = _context.Skladistes.AsQueryable();
                //.Include(i => i.UlazUSkladiste)
                

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().Contains(search.Naziv.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.Vrsta))
            {
                query = query.Where(x => x.Vrsta.ToLower().Contains(search.Vrsta.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.Proizvodjac))
            {
                query = query.Where(x => x.Proizvodjac.ToLower().Contains(search.Proizvodjac.ToLower()));
            }
            var entities = query.ToList();
            var result = _mapper.Map<List<Model.Skladiste>>(entities);
            return result;
        }
        public override Model.Skladiste Insert(SkladisteInsertRequest request)
        {
            var entity = _mapper.Map<Database.Skladiste>(request);
            var proizvodPostoji = _context.Skladistes.FirstOrDefault(i => i.Naziv == entity.Naziv && i.Proizvodjac == entity.Proizvodjac);
            if (proizvodPostoji != null)
            {
                proizvodPostoji.Kolicina = proizvodPostoji.Kolicina + entity.Kolicina;
                proizvodPostoji.Cijena = entity.Cijena;
                _context.SaveChanges();

                return _mapper.Map<Model.Skladiste>(proizvodPostoji);
            }

            _context.Add(entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Skladiste>(entity);
        }
        public override Model.Skladiste Update(int id, SkladisteInsertRequest request)
        {
            var entity = _context.Skladistes.Find(id);
            var exSlika=request.Slika;
            if (request.Slika == null)
            {
                exSlika = entity.Slika;

            }

            _mapper.Map(request, entity);
            entity.Slika = exSlika;
            _context.SaveChanges();

            return _mapper.Map<Model.Skladiste>(entity);
        }
    }
}
