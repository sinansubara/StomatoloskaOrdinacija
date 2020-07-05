using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    public class DijagnozaController : BaseController<Model.Dijagnoza, object>
    {
        public DijagnozaController(IService<Dijagnoza, object> service) : base(service)
        {
        }
    }
}