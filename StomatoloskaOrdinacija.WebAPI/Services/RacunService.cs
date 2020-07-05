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
    public class RacunService : BaseCRUDService<Model.Racun, RacunSearchRequest, RacunInsertRequest, RacunUpdateRequest, Database.Racun>
    {

        public RacunService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.Racun> GetAll(RacunSearchRequest search = default)
        {
            var query = _context.Racuns
                .Include(i=>i.Korisnici)
                .Include(i=>i.Korisnici.Grad)
                .Include(i=>i.Korisnici.Grad.Drzava)
                .Include(i=>i.Korisnici.Uloga)
                .Include(i=>i.Pregled)
                .Include(i=>i.Pregled.Lijek)
                .Include(i=>i.Pregled.Dijagnoza)
                .Include(i=>i.Pregled.Skladiste)
                .Include(i=>i.Pregled.Skladiste.UlazUSkladiste)
                .Include(i=>i.Pregled.Termin)
                .Include(i=>i.Pregled.Termin.Usluga)
                .AsQueryable();

            if (search?.KorisnikId != 0)
            {
                query = query.Where(x => x.Korisnici.KorisnikId == search.KorisnikId);
            }
            if (search?.PregledId != 0)
            {
                query = query.Where(x => x.Pregled.PregledId == search.PregledId);
            }
            if (search?.Dan != 0)
            {
                query = query.Where(x => x.DatumIzdavanjaRacuna.Day == search.Dan);
            }
            if (search?.Mjesec != 0)
            {
                query = query.Where(x => x.DatumIzdavanjaRacuna.Month == search.Mjesec);
            }
            if (search?.Godina != 0)
            {
                query = query.Where(x => x.DatumIzdavanjaRacuna.Year == search.Godina);
            }

            var entities = query.ToList();
            var result = _mapper.Map<List<Model.Racun>>(entities);
            return result;
        }

        public override Model.Racun Insert(RacunInsertRequest request)
        {
            var entity = _mapper.Map<Database.Racun>(request);
            
            _context.Add(entity);

            decimal snizenje = 0;
            var pregled = _context.Pregleds
                .Include(i=>i.Termin)
                .Include(i=>i.Termin.Usluga)
                .FirstOrDefault(i => i.PregledId == entity.PregledId);
            var IsSnizeno = _context.Popusts.FirstOrDefault(i => i.UslugaId == pregled.Termin.UslugaId);
            if (IsSnizeno != null)
            {
                snizenje = (pregled.Termin.Usluga.Cijena) - ((pregled.Termin.Usluga.Cijena * IsSnizeno.VrijednostPopusta) / 100);
            }
            var skladisteMaterijal = _context.Skladistes.FirstOrDefault(i => i.SkladisteId == pregled.SkladisteId);
            var formirajCijenu = (skladisteMaterijal.Cijena * pregled.KolicinaOdabranogMaterijala) + snizenje;


            entity.IsPlatio = false;
            entity.UkupnaCijena = formirajCijenu;
            entity.DatumIzdavanjaRacuna = DateTime.Now;

            _context.SaveChanges();

            return _mapper.Map<Model.Racun>(entity);
        }

        public override Model.Racun Update(int id, RacunUpdateRequest request)
        {
            var entity = _context.Racuns.Find(id);

            _mapper.Map(request, entity);
            entity.IsPlatio = request.IsPlatio;
            _context.SaveChanges();

            return _mapper.Map<Model.Racun>(entity);
        }
    }
}
