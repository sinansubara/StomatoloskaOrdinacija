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
    public class PretplataController : BaseCRUDController<Model.Pretplata, PretplataSearchRequest, PretplataInsertRequest, PretplataInsertRequest>
    {
        public PretplataController(ICRUDService<Pretplata, PretplataSearchRequest, PretplataInsertRequest, PretplataInsertRequest> service) : base(service)
        {
        }
    }
}