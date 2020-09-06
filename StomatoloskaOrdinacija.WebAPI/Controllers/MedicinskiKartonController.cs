using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    public class MedicinskiKartonController : BaseController<Model.MedicinskiKarton, MedicinskiKartonSearchRequest>
    {
        private static MyContext _context;
        public MedicinskiKartonController(MyContext context, IService<Model.MedicinskiKarton, MedicinskiKartonSearchRequest> service) : base(service)
        {
            _context = context;
        }

        [HttpGet("getallbydatum")]
        public IList<Model.MedicinskiKarton> GetAllByDatum([FromQuery] MedicinskiKartonSearchRequest search = default)
        {
            var pregledi = _context.MedicinskiKartons
                .Include(i=>i.Pacijent.Korisnici)
                .Include(i=>i.Pregled.Termin.Usluga)
                .Where(i=>i.Datum.Year == search.DatumPretrageReport.Year &&
                       i.Datum.Month == search.DatumPretrageReport.Month &&
                       i.Datum.Day == search.DatumPretrageReport.Day).ToList();

            var result = new List<Model.MedicinskiKarton>();
            foreach (var pregled in pregledi)
            {
                var temp = _context.Racuns.FirstOrDefault(i => i.PregledId == pregled.PregledId);
                if (temp != null)
                {
                    result.Add(new Model.MedicinskiKarton
                    {
                        PregledId = temp.PregledId,
                        PacijentId = pregled.PacijentId,
                        Datum = pregled.Datum,
                        Napomena = pregled.Napomena,
                        ImePacijenta = pregled.Pacijent.Korisnici.Ime + " " + pregled.Pacijent.Korisnici.Prezime,
                        ImeUsluge = pregled.Pregled.Termin.Usluga.Naziv,
                        Cijena = temp.UkupnaCijena
                    });
                }
            }

            return result;
        }
    }
}