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
    public class PopustController : BaseCRUDController<Model.Popust, PopustSearchRequest, PopustInsertRequest, PopustInsertRequest>
    {
        private static MyContext _context;
        public PopustController(MyContext context, ICRUDService<Model.Popust, PopustSearchRequest, PopustInsertRequest, PopustInsertRequest> service) : base(service)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public Model.Popust DeleteById(int id)
        {
            var temp = _context.Popusts.FirstOrDefault(i => i.PopustId == id);
            
            if (temp != null)
            {
                _context.Popusts.Remove(temp);
                _context.SaveChanges();
            }
            else
            {
                throw new UserException("Popust koji zelite da izbrisete, ne postoji!");
            }

            return new Model.Popust();
        }
    }
}