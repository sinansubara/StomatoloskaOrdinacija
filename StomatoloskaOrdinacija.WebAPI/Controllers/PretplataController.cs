using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Filters;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    public class PretplataController : BaseCRUDController<Model.Pretplata, PretplataSearchRequest, PretplataInsertRequest, PretplataInsertRequest>
    {
        private static MyContext _context;
        public PretplataController(MyContext context, ICRUDService<Model.Pretplata, PretplataSearchRequest, PretplataInsertRequest, PretplataInsertRequest> service) : base(service)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public Model.Pretplata DeleteById(int id)
        {
            var temp = _context.Pretplatas.FirstOrDefault(i => i.PretplataId == id);
            
            if (temp != null)
            {
                _context.Pretplatas.Remove(temp);
                _context.SaveChanges();
            }
            else
            {
                throw new UserException("Pretplata koju zelite da izbrisete, ne postoji!");
            }

            return new Model.Pretplata();
        }
    }
}