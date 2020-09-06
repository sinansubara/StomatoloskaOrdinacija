using AutoMapper;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Filters;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public class MedicinskiKartonService : BaseService<Model.MedicinskiKarton, MedicinskiKartonSearchRequest, Database.MedicinskiKarton>
    {

        public MedicinskiKartonService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.MedicinskiKarton> GetAll(MedicinskiKartonSearchRequest search = default)
        {
            var query = _context.MedicinskiKartons
                .Include(i=>i.Pacijent)
                .Include(i=>i.Pacijent.Korisnici)
                .Include(i=>i.Pregled)
                .Include(i=>i.Pregled.Lijek)
                .Include(i=>i.Pregled.Dijagnoza)
                .Include(i=>i.Pregled.Skladiste)
                .Include(i=>i.Pregled.Skladiste.UlazUSkladiste)
                .Include(i=>i.Pregled.Termin)
                .Include(i=>i.Pregled.Termin.Usluga)
                .AsQueryable();

            if (search?.PregledId != 0)
            {
                query = query.Where(x => x.Pregled.PregledId == search.PregledId);
            }
            if (search?.PacijentId != 0)
            {
                query = query.Where(x => x.Pacijent.PacijentId == search.PacijentId);
            }
            if (search?.Dan != 0)
            {
                query = query.Where(x => x.Datum.Day == search.Dan);
            }
            if (search?.Mjesec != 0)
            {
                query = query.Where(x => x.Datum.Month == search.Mjesec);
            }
            if (search?.Godina != 0)
            {
                query = query.Where(x => x.Datum.Year == search.Godina);
            }
            var entities = query.ToList();
            var result = _mapper.Map<IList<Model.MedicinskiKarton>>(entities);
            return result;
        }
    }
}
