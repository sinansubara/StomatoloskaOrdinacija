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
    public class UlazUSkladisteController : BaseCRUDController<Model.UlazUSkladiste, UlazUSkladisteSearchRequest, UlazUSkladisteInsertRequest, UlazUSkladisteInsertRequest>
    {
        public UlazUSkladisteController(ICRUDService<UlazUSkladiste, UlazUSkladisteSearchRequest, UlazUSkladisteInsertRequest, UlazUSkladisteInsertRequest> service) : base(service)
        {
        }
    }
}