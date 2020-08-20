using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    public class UslugaController : BaseCRUDController<Model.Usluga, UslugaSearchRequest, UslugaInsertRequest, UslugaInsertRequest>
    {
        private static MyContext _context;
        private static IMapper _mapper;
        public UslugaController(MyContext context, IMapper mapper, ICRUDService<Model.Usluga, 
                                                    UslugaSearchRequest, 
                                                    UslugaInsertRequest, 
                                                    UslugaInsertRequest> service) : base(service)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("uslugepozaradi")]
        public IList<Model.Usluga> UslugePoZaradi()
        {
            var usluge = _context.Uslugas.ToList();
            decimal suma = 0;
            var lista = new List<Model.Usluga>();
            foreach (var usluga in usluge)
            {
                var test = _context.Pregleds
                    .Include(i=>i.Termin)
                    .Include(i=>i.Termin.Usluga)
                    .Where(i => i.Termin.Usluga.UslugaId == usluga.UslugaId);
                if (test.FirstOrDefault() != null)
                {
                    var novaUsluga = _mapper.Map<Model.Usluga>(usluga);
                    novaUsluga.SumaCijena = test.Sum(i => i.Termin.Usluga.Cijena);
                    lista.Add(novaUsluga);
                }
            }
            var temp = lista.OrderByDescending(i => i.SumaCijena).ToList();

            return temp;
        }
    }
}