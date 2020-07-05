using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    public class SkladisteController : BaseCRUDController<Model.Skladiste, SkladisteSearchRequest, SkladisteInsertRequest, SkladisteInsertRequest>
    {
        public SkladisteController(ICRUDService<Skladiste, SkladisteSearchRequest, SkladisteInsertRequest, SkladisteInsertRequest> service) : base(service)
        {
        }
    }
}