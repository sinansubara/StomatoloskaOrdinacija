using AutoMapper;
using StomatoloskaOrdinacija.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public class BaseService<T, TSearch, TDb> : IService<T, TSearch> where TDb : class
    {
        protected MyContext _context;
        protected IMapper _mapper;
        
        public BaseService(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual IList<T> GetAll(TSearch search = default)
        {
            var result = _context.Set<TDb>().ToList();
            return _mapper.Map<IList<T>>(result);
        }

        public virtual T GetById(int id)
        {
            var entity = _context.Set<TDb>().Find(id);
            return _mapper.Map<T>(entity);
        }
    }
}
