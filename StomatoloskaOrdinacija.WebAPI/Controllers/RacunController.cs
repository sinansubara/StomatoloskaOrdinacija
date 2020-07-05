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
    public class RacunController : BaseCRUDController<Model.Racun, RacunSearchRequest, RacunInsertRequest, RacunUpdateRequest>
    {
        public RacunController(ICRUDService<Racun, RacunSearchRequest, RacunInsertRequest, RacunUpdateRequest> service) : base(service)
        {
        }
    }
}