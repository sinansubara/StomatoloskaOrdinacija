using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    public class TerminController : BaseCRUDController<Model.Termin, 
                                                             TerminSearchRequest, 
                                                             TerminInsertRequest, 
                                                             TerminInsertRequest>
    {
        private static MyContext _context;
        public TerminController(MyContext context, ICRUDService<Model.Termin, 
                                              TerminSearchRequest, 
                                              TerminInsertRequest, 
                                              TerminInsertRequest> service) : base(service)
        {
            _context = context;
        }

        [HttpPut("odbij/{id}")]
        public Model.Termin Odbij(int id, [FromBody]TerminSearchRequest request)
        {
            var entity = _context.Termins.Find(id);
            
            entity.IsNaCekanju = false;
            entity.IsOdobren = false;
            _context.SaveChanges();
            var noviModel = new Model.Termin
            {
                DatumVrijeme = entity.DatumVrijeme,
                Hitan = entity.Hitan,
                IsNaCekanju = entity.IsNaCekanju,
                IsOdobren = entity.IsOdobren,
                PacijentId = entity.PacijentId,
                Razlog = entity.Razlog, 
                TerminId = entity.TerminId,
                UslugaId = entity.UslugaId
            };
            return noviModel;
        }
        [HttpPut("prihvati/{id}")]
        public Model.Termin Prihvati(int id, [FromBody]TerminSearchRequest request)
        {
            var entity = _context.Termins.Find(id);
            
            entity.IsNaCekanju = false;
            entity.IsOdobren = true;
            _context.SaveChanges();
            var noviModel = new Model.Termin
            {
                DatumVrijeme = entity.DatumVrijeme,
                Hitan = entity.Hitan,
                IsNaCekanju = entity.IsNaCekanju,
                IsOdobren = entity.IsOdobren,
                PacijentId = entity.PacijentId,
                Razlog = entity.Razlog, 
                TerminId = entity.TerminId,
                UslugaId = entity.UslugaId
            };
            return noviModel;
        }
        
    }
}