﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.WebAPI.Services.Interfaces
{
    public interface IService<T, TSearch>
    {
        IList<T> GetAll(TSearch search = default(TSearch));

        T GetById(int id);
    }
}
