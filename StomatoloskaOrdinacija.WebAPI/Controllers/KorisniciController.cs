using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        protected IKorisniciService _service;

        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Model.Korisnici> GetAll([FromQuery]KorisniciSearchRequest request)
        {
            return _service.GetAll(request);
        }

        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsertRequest korisnici)
        {
            return _service.Insert(korisnici);
        }

        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, [FromBody]KorisniciUpdateRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpPost("login")]
        public Model.Korisnici Login(KorisniciLoginRequest request)
        {
            return _service.Login(request);
        }
        [AllowAnonymous]
        [HttpPost("registracija")]
        public Model.Korisnici Registracija(KorisniciRegistracijaRequest request)
        {
            return _service.Registracija(request);
        }
        [HttpPost("loginmobile")]
        public Model.Korisnici LoginMobile(KorisniciLoginRequest request)
        {
            return _service.LoginMobile(request);
        }

        [HttpGet("pacijenti")]
        public IList<Model.Pacijent> GetAllPacijenti([FromQuery]KorisniciSearchRequest request)
        {
            return _service.GetAllPacijenti(request);
        }
        [HttpPut("pacijenti")]
        public Model.Pacijent Update(int id, [FromBody] KorisniciPacijentUpdateRequest request)
        {
            return _service.Update(id, request);
        }
        [HttpGet("korisnikpacijenti")]
        public IList<Model.KorisnikPacijent> GetAllKorisnikPacijenti([FromQuery]KorisniciSearchRequest request)
        {
            return _service.GetAllKorisnikPacijenti(request);
        }
        [HttpGet("pacijenti/{id}")]
        public Model.KorisnikPacijent GetByIdKorisnikPacijent(int id)
        {
            return _service.GetByIdKorisnikPacijent(id);
        }
        [HttpPut("pacijenti/{id}")]
        public Model.KorisnikPacijent UpdateKorisniciPacijent(int id, [FromBody]KorisniciPacijentUpdateRequest request)
        {
            return _service.UpdateKorisniciPacijent(id, request);
        }
        [HttpPost("najboljistomatolog")]
        public Model.Korisnici GetNajboljiStomatolog([FromQuery]KorisniciSearchRequest request)
        {
            return _service.GetNajboljiStomatolog();
        }
        [HttpPost("najboljeosoblje")]
        public Model.Korisnici GetNajboljeOsoblje([FromQuery]KorisniciSearchRequest request)
        {
            return _service.GetNajboljeOsoblje();
        }
        [HttpPost("najboljipacijent")]
        public Model.Korisnici GetNajBoljiPacijent([FromQuery]KorisniciSearchRequest request)
        {
            return _service.GetNajBoljiPacijent();
        }

        [HttpGet("getalldatumoddo")]
        public IList<Model.Korisnici> GetAllDatumOdDo([FromQuery] KorisniciSearchRequest search = default)
        {
            return _service.GetAllDatumOdDo(search);
        }
        [HttpGet("toppacijenti")]
        public IList<Model.Korisnici> TopPacijenti([FromQuery] KorisniciSearchRequest search = default)
        {
            return _service.TopPacijenti(search);
        }
        
    }
}