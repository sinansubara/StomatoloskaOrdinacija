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
using StomatoloskaOrdinacija.WebAPI.CBF;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;
using Termin = StomatoloskaOrdinacija.Model.Termin;
using Usluga = StomatoloskaOrdinacija.Model.Usluga;

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public class UslugaService : BaseCRUDService<Model.Usluga, UslugaSearchRequest, UslugaInsertRequest, UslugaInsertRequest, Database.Usluga>
    {
        
        public UslugaService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.Usluga> GetAll(UslugaSearchRequest search = default)
        {
            var query = _context.Uslugas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().Contains(search.Naziv.ToLower()));
            }

            var novaLista = new List<Database.Usluga>();
            var entities = query.ToList();
            if (search?.IsPretplacen == "Ne" && search?.PacijentId != 0)
            {
                foreach (var usluga in entities)
                {
                    var flag = _context.Pretplatas.FirstOrDefault(i => i.UslugaId == usluga.UslugaId && i.PacijentId == search.PacijentId);
                    if (flag == null)
                    {
                        novaLista.Add(usluga);
                    }
                }
                var result2 = _mapper.Map<List<Model.Usluga>>(novaLista);
                return result2;
            }
            
            var result = _mapper.Map<List<Model.Usluga>>(entities);
            return result;
        }

    }
}
