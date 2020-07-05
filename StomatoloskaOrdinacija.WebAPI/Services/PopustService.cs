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
    public class PopustService : BaseCRUDService<Model.Popust, PopustSearchRequest, PopustInsertRequest, PopustInsertRequest, Database.Popust>
    {

        public PopustService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.Popust> GetAll(PopustSearchRequest search = default)
        {
            var query = _context.Popusts
                .Include(i=>i.Korisnici)
                .Include(i=>i.Usluga)
                .AsQueryable();

            if (search?.UslugaId != 0)
            {
                query = query.Where(x => x.Usluga.UslugaId == search.UslugaId);
            }

            var entities = query.ToList();
            var result = _mapper.Map<List<Model.Popust>>(entities);
            return result;
        }

        public override Model.Popust Insert(PopustInsertRequest request)
        {
            if (request.PopustOdDatuma > request.PopustDoDatuma)//ako je datum od veci od datuma do
            {
                var tempDatum = request.PopustOdDatuma;
                request.PopustOdDatuma = request.PopustDoDatuma; 
                request.PopustDoDatuma = tempDatum;
            }
            var entity = _mapper.Map<Database.Popust>(request);
            
            _context.Add(entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Popust>(entity);
        }
        public override Model.Popust Update(int id, PopustInsertRequest request)
        {
            if (request.PopustOdDatuma > request.PopustDoDatuma)//ako je datum od veci od datuma do
            {
                var tempDatum = request.PopustOdDatuma;
                request.PopustOdDatuma = request.PopustDoDatuma; 
                request.PopustDoDatuma = tempDatum;
            }
            var entity = _context.Popusts.Find(id);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Popust>(entity);
        }
    }
}
