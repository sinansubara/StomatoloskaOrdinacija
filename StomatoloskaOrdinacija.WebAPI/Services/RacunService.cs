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
                .Include(i=>i.Pregled.Skladiste)
                .Include(i=>i.Pregled.Termin.Usluga)
                .Include(i=>i.Pregled.Termin.Pacijent.Korisnici)
                .AsQueryable();

            if (search?.RacunId != 0)
            {
                query = query.Where(x => x.RacunId == search.RacunId);
            }
            if (search?.KorisnikId != 0)
            {
                query = query.Where(x => x.Korisnici.KorisnikId == search.KorisnikId);
            }
            if (search?.PacijentId != 0)
            {
                query = query.Where(x => x.Pregled.Termin.PacijentId == search.PacijentId);
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
            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Pregled.Termin.Pacijent.Korisnici.Ime == search.Ime);
            }
            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Pregled.Termin.Pacijent.Korisnici.Prezime == search.Prezime);
            }
            if (search?.NijeUplatioRequest == true)
            {
                query = query.Where(x => x.IsPlatio == false);
            }

            var entities = query.ToList();
            var result = _mapper.Map<List<Model.Racun>>(entities);

            foreach (var finalRacunlist in result)
            {
                finalRacunlist.RacunDoktorIme = finalRacunlist.Korisnici.Ime + " " + finalRacunlist.Korisnici.Prezime;
                    finalRacunlist.PregledPacijentIme = finalRacunlist.Pregled.Termin.Pacijent.Korisnici.Ime + " " +
                                                        finalRacunlist.Pregled.Termin.Pacijent.Korisnici.Prezime;
                    finalRacunlist.PregledUslugaNaziv = finalRacunlist.Pregled.Termin.Usluga.Naziv;
                    finalRacunlist.PregledMaterijalNaziv = finalRacunlist.Pregled.Skladiste.Naziv;
                    finalRacunlist.PregledMaterijalKolicina = finalRacunlist.Pregled.KolicinaOdabranogMaterijala.ToString("F");
            }



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
            var IsSnizeno = _context.Popusts.FirstOrDefault(i =>
                                    i.UslugaId == pregled.Termin.UslugaId && 
                                    i.PopustOdDatuma < DateTime.Now &&
                                    i.PopustDoDatuma > DateTime.Now);
            if (IsSnizeno != null)
            {
                snizenje = (pregled.Termin.Usluga.Cijena) - ((pregled.Termin.Usluga.Cijena * IsSnizeno.VrijednostPopusta) / 100);
            }
            else
            {
                snizenje = pregled.Termin.Usluga.Cijena;
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
            entity.DatumIzdavanjaRacuna = DateTime.Now;
            _context.SaveChanges();

            return _mapper.Map<Model.Racun>(entity);
        }
    }
}
