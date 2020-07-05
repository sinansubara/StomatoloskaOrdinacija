using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StomatoloskaOrdinacija.WebAPI.Database;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MaterijaliController : ControllerBase
    {
        protected MyContext _context;
        protected IMapper _mapper;
        public MaterijaliController(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IList<Model.Materijali> GetTop10()
        {
            var skladistestavke = _context.Skladistes.ToList();
            decimal zbir = 0;
            var lista = new List<Model.Materijali>();
            foreach (var skladiste in skladistestavke)
            {
                var test = _context.Materijalis.Where(i => i.SkladisteId == skladiste.SkladisteId);
                if(test.FirstOrDefault() != null)
                {
                    var novi = _mapper.Map<Model.Materijali>(test.FirstOrDefault());
                    novi.Zbir = test.Select(i => i.Kolicina).Sum();
                    lista.Add(novi);
                }
                
            }

            var temp = lista.OrderByDescending(i => i.Kolicina).Take(10).ToList();
            return temp;
        }
    }
}