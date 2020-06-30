﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
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

    }
}