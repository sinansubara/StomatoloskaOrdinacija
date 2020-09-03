using AutoMapper;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Filters;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public class PregledService : BaseCRUDService<Model.Pregled, PregledSearchRequest, PregledInsertRequest, PregledInsertRequest, Database.Pregled>
    {

        public PregledService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IList<Model.Pregled> GetAll(PregledSearchRequest search = default)
        {
            var query = _context.Pregleds
                .Include(i=>i.Dijagnoza)
                .Include(i=>i.Termin.Usluga)
                .Include(i=>i.Termin.Pacijent.Korisnici)
                .Include(i=>i.Korisnici)
                .Include(i=>i.Lijek)
                .Include(i=>i.Skladiste)
                .AsQueryable();

            if (search?.KorisnikId != 0)
            {
                query = query.Where(x => x.Korisnici.KorisnikId == search.KorisnikId);
            }
            if (search?.TerminId != 0)
            {
                query = query.Where(x => x.Termin.TerminId == search.TerminId);
            }
            if (search?.SkladisteId != 0)
            {
                query = query.Where(x => x.Skladiste.SkladisteId == search.SkladisteId);
            }
            if (!string.IsNullOrWhiteSpace(search?.Napomena))
            {
                query = query.Where(x => x.Napomena.ToLower().Contains(search.Napomena.ToLower()));
            }
            var entities = query.ToList();
            var NovaLista = new List<Database.Pregled>();

            if (search.IsUplacenPregledRequest == "Ne")
            {
                foreach (var pregled in entities)
                {
                    var flag = _context.Racuns.FirstOrDefault(i => i.PregledId == pregled.PregledId && i.IsPlatio == false);
                    if (flag != null)
                    {
                        NovaLista.Add(pregled);
                    }
                }

                var result1 = _mapper.Map<List<Model.Pregled>>(NovaLista);
                foreach (var convert in result1)
                {
                    convert.PregledIme = "Usluga: " + convert.Termin.Usluga.Naziv + "  |   Pacijent: " + convert.Termin.Pacijent.Korisnici.Ime + " " +
                                        convert.Termin.Pacijent.Korisnici.Prezime;
                }
                return result1;
            }



            var result = _mapper.Map<List<Model.Pregled>>(entities);

            foreach (var finalPregledlist in result)
            {
               
                    finalPregledlist.DijagnozaTekst = finalPregledlist.Dijagnoza.Naziv;
                    finalPregledlist.DoktorIme = finalPregledlist.Korisnici.Ime + " " + finalPregledlist.Korisnici.Prezime;
                    finalPregledlist.Materijal = finalPregledlist.Skladiste.Naziv;
                    finalPregledlist.LijekTekst = finalPregledlist.Lijek.Naziv;
                    finalPregledlist.TerminRazlog = finalPregledlist.Termin.Razlog;
                    finalPregledlist.TerminImePacijenta =
                        finalPregledlist.Termin.Pacijent.Korisnici.Ime + " " + finalPregledlist.Termin.Pacijent.Korisnici.Prezime;
            }

            return result;
        }

        public override Model.Pregled Insert(PregledInsertRequest request)
        {
            var provjera = _context.Termins.FirstOrDefault(i => i.TerminId == request.TerminId);
            if (provjera != null && !provjera.IsOdobren)
            {
                if (provjera.IsNaCekanju)
                {
                    provjera.IsOdobren = true;
                    provjera.IsNaCekanju = false;
                }
                else
                {
                    throw new UserException("Termin je odbijen!");
                }
                
            }

            var flag = _context.Pregleds.FirstOrDefault(i => i.TerminId == request.TerminId);
            if (flag != null)
                throw new UserException("Termin je vec iskoristen za neki drugi pregled!");

            var kolicinaNaSkladistu =
                _context.Skladistes.FirstOrDefault(i => i.SkladisteId == request.SkladisteId);

            if (kolicinaNaSkladistu != null && kolicinaNaSkladistu.Kolicina < request.KolicinaOdabranogMaterijala)
            {
                throw new UserException("Unijeli ste kolicinu materijala vecu nego sto ima na skladistu!");
            }
            if (kolicinaNaSkladistu != null && kolicinaNaSkladistu.Kolicina >= request.KolicinaOdabranogMaterijala)
            {
                kolicinaNaSkladistu.Kolicina = kolicinaNaSkladistu.Kolicina - request.KolicinaOdabranogMaterijala;
                _context.SaveChanges();
            }
            var noviRecordOpotrosnji = new Database.Materijali
            {
                Datum = DateTime.Now,
                Kolicina = request.KolicinaOdabranogMaterijala,
                Naziv = kolicinaNaSkladistu.Naziv,
                SkladisteId = request.SkladisteId
            };
            _context.Add(noviRecordOpotrosnji);
            var entity = _mapper.Map<Database.Pregled>(request);
            
            _context.Add(entity);

            _context.SaveChanges();

            var pacijent = _context.Termins.FirstOrDefault(i => i.TerminId == entity.TerminId).PacijentId;

            var medicinskiKarton = new Database.MedicinskiKarton
            {
                Datum = DateTime.Now,
                Napomena = entity.Napomena,
                PacijentId = pacijent,
                PregledId = entity.PregledId
            };
            _context.MedicinskiKartons.Add(medicinskiKarton);
            _context.SaveChanges();


            return _mapper.Map<Model.Pregled>(entity);
        }

        public override Model.Pregled GetById(int id)
        {
            var entity = _context.Pregleds
                .Include(i=>i.Korisnici)
                .Include(i => i.Termin)
                .Include(i => i.Termin.Usluga)
                .Include(i => i.Termin.Pacijent)
                .Include(i => i.Termin.Pacijent.Korisnici)
                .Include(i => i.Skladiste)
                .Include(i => i.Lijek)
                .Include(i => i.Dijagnoza).FirstOrDefault(i => i.PregledId == id);


            return _mapper.Map<Model.Pregled>(entity);
        }

        public override Model.Pregled Update(int id, PregledInsertRequest request)
        {
            var pretragaPregled = _context.Pregleds.FirstOrDefault(i => i.PregledId == id);

            var kolicinaNaSkladistu =
                _context.Skladistes.FirstOrDefault(i => i.SkladisteId == request.SkladisteId);

            if (kolicinaNaSkladistu != null && kolicinaNaSkladistu.Kolicina < request.KolicinaOdabranogMaterijala)
            {
                throw new UserException("Unijeli ste kolicinu materijala vecu nego sto ima na skladistu!");
            }

            if (kolicinaNaSkladistu != null && kolicinaNaSkladistu.Kolicina >= request.KolicinaOdabranogMaterijala)
            {
                kolicinaNaSkladistu.Kolicina = kolicinaNaSkladistu.Kolicina -
                                               (request.KolicinaOdabranogMaterijala -
                                                pretragaPregled.KolicinaOdabranogMaterijala);//testiraj
                _context.SaveChanges();
            }

            _mapper.Map(request, pretragaPregled);
            _context.SaveChanges();

            var updateMedicinskiKarton = _context.MedicinskiKartons.FirstOrDefault(i => i.PregledId == id);
            if (updateMedicinskiKarton != null)
            {
                updateMedicinskiKarton.Datum = DateTime.Now;
                updateMedicinskiKarton.Napomena = pretragaPregled.Napomena;
            }
            _context.SaveChanges();

            return _mapper.Map<Model.Pregled>(pretragaPregled);
        }

    }
}
