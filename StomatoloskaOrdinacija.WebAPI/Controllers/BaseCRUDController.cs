﻿using StomatoloskaOrdinacija.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _crudService;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _crudService = service;
        }

        [HttpPost]
        public T Insert(TInsert request)
        {
            return _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public T Update(int id, [FromBody]TUpdate request)
        {
            return _crudService.Update(id, request);
        }
    }
}
