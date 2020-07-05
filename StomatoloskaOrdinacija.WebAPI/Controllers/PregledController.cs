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
    public class PregledController : BaseCRUDController<Model.Pregled, PregledSearchRequest, PregledInsertRequest, PregledInsertRequest>
    {
        public PregledController(ICRUDService<Pregled, PregledSearchRequest, PregledInsertRequest, PregledInsertRequest> service) : base(service)
        {
        }
    }
}