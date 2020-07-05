using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    public class PopustController : BaseCRUDController<Model.Popust, PopustSearchRequest, PopustInsertRequest, PopustInsertRequest>
    {
        public PopustController(ICRUDService<Popust, PopustSearchRequest, PopustInsertRequest, PopustInsertRequest> service) : base(service)
        {
        }
    }
}