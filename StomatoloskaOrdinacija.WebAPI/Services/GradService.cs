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
using Microsoft.AspNetCore.Authorization;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public class GradService : BaseCRUDService<Model.Grad, GradSearchRequest, GradUpsertRequest, GradUpsertRequest, Database.Grad>
    {

        public GradService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Model.Grad> GetAll(GradSearchRequest search = default)
        {
            var query = _context.Grads
                .Include(i=>i.Drzava)
                .AsQueryable();

            if (search?.DrzavaId != 0)
            {
                query = query.Where(x => x.Drzava.DrzavaId == search.DrzavaId);
            }
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv == search.Naziv);
            }
            if (!string.IsNullOrWhiteSpace(search?.PostanskiBroj))
            {
                query = query.Where(x => x.PostanskiBroj == search.PostanskiBroj);
            }
            var entities = query.ToList();
            var result = _mapper.Map<IList<Model.Grad>>(entities);
            return result;
        }

    }
}
