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
    public class PretplataService : BaseCRUDService<Model.Pretplata, PretplataSearchRequest, PretplataInsertRequest, PretplataInsertRequest, Database.Pretplata>
    {

        public PretplataService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.Pretplata> GetAll(PretplataSearchRequest search = default)
        {
            var query = _context.Pretplatas
                .Include(i=>i.Pacijent)
                .Include(i=>i.Usluga)
                .AsQueryable();

            if (search?.PacijentId != 0)
            {
                query = query.Where(x => x.Pacijent.PacijentId == search.PacijentId);
            }
            if (search?.UslugaId != 0)
            {
                query = query.Where(x => x.Usluga.UslugaId == search.UslugaId);
            }
            if (search?.Dan != 0)
            {
                query = query.Where(x => x.DatumPretplate.Day == search.Dan);
            }
            if (search?.Mjesec != 0)
            {
                query = query.Where(x => x.DatumPretplate.Month == search.Mjesec);
            }
            if (search?.Godina != 0)
            {
                query = query.Where(x => x.DatumPretplate.Year == search.Godina);
            }
            
            var entities = query.ToList();
            //var novaLista = new List<Database.Pretplata>();
            var novaLista = new List<Model.Pretplata>();
            if (search?.IsNaSnizenju == "Da")
            {
                foreach (var pretplata in entities)
                {
                    var flag = _context.Popusts.FirstOrDefault(i =>
                        i.PopustOdDatuma < DateTime.Now && i.PopustDoDatuma > DateTime.Now && pretplata.UslugaId == i.UslugaId);
                    if (flag != null)
                    {
                        var temp = _mapper.Map<Model.Pretplata>(pretplata);
                        temp.SnizenaCijena =
                            (temp.Usluga.Cijena) - ((temp.Usluga.Cijena * flag.VrijednostPopusta) / 100);
                        novaLista.Add(temp);
                    }
                }
               
                return novaLista;
            }
            var result = _mapper.Map<List<Model.Pretplata>>(entities);
            return result;
        }

        public override Model.Pretplata Insert(PretplataInsertRequest request)
        {
            var provjera =
                _context.Pretplatas.FirstOrDefault(i => i.PacijentId == request.PacijentId && i.UslugaId == request.UslugaId);
            if (provjera != null)
            {
                if (provjera.IsAktivna == false)
                {
                    provjera.IsAktivna = true;
                    provjera.DatumPretplate = DateTime.Now;
                    _context.SaveChanges();
                    return _mapper.Map<Model.Pretplata>(provjera);
                }

                if (provjera.IsAktivna)
                {
                    if (request.IsAktivna == false)
                    {
                        provjera.IsAktivna = false;
                        _context.SaveChanges();
                        return _mapper.Map<Model.Pretplata>(provjera);
                    }
                    throw new UserException("Već ste pretplaćeni na ovu uslugu!");
                }
            }
            var entity = _mapper.Map<Database.Pretplata>(request);
            
            _context.Add(entity);
            entity.DatumPretplate = DateTime.Now;

            _context.SaveChanges();

            return _mapper.Map<Model.Pretplata>(entity);
        }
    }
}
