using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.CBF;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;
using Usluga = StomatoloskaOrdinacija.Model.Usluga;

namespace StomatoloskaOrdinacija.WebAPI.Controllers
{
    public class UslugaController : BaseCRUDController<Model.Usluga, UslugaSearchRequest, UslugaInsertRequest, UslugaInsertRequest>
    {
        private static MyContext _context;
        private static IMapper _mapper;
        private readonly CBF.CBF _cbf = new CBF.CBF();
        private readonly WordBagGenerator _wordGenerator = new WordBagGenerator();
        public UslugaController(MyContext context, IMapper mapper, ICRUDService<Model.Usluga, 
                                                    UslugaSearchRequest, 
                                                    UslugaInsertRequest, 
                                                    UslugaInsertRequest> service) : base(service)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("uslugepozaradi")]
        public IList<Model.Usluga> UslugePoZaradi()
        {
            var usluge = _context.Uslugas.ToList();
            //decimal suma = 0;
            var lista = new List<Model.Usluga>();
            foreach (var usluga in usluge)
            {
                var test = _context.Pregleds
                    .Include(i=>i.Termin)
                    .Include(i=>i.Termin.Usluga)
                    .Where(i => i.Termin.Usluga.UslugaId == usluga.UslugaId);
                if (test.FirstOrDefault() != null)
                {
                    var novaUsluga = _mapper.Map<Model.Usluga>(usluga);
                    novaUsluga.SumaCijena = test.Sum(i => i.Termin.Usluga.Cijena);
                    lista.Add(novaUsluga);
                }
            }
            var temp = lista.OrderByDescending(i => i.SumaCijena).ToList();

            return temp;
        }
        [HttpGet("RecommendedUsluge/{PacijentId}")]
        public List<Model.Usluga> RecommendedUsluge(int PacijentId)
        {
            var pacijentoviTermini = _context.Termins.Where(x => x.PacijentId == PacijentId)
                .Include(x => x.Pacijent)
                .ThenInclude(x => x.Korisnici)
                .ThenInclude(x => x.Grad)
                .ThenInclude(x => x.Drzava)
                .Include(x => x.Usluga).ToList();
            var pacijentoveOcjene = _context.Ocjenes.Where(x => x.PacijentId == PacijentId)
                .Include(x => x.Usluga)
                .Include(x => x.Pacijent)
                .ThenInclude(x => x.Korisnici)
                .ThenInclude(x => x.Grad)
                .ThenInclude(x => x.Drzava).ToList();
            var pacijentovePretplate = _context.Pretplatas.Where(x => x.PacijentId == PacijentId)
                .Include(x => x.Usluga)
                .Include(x => x.Pacijent)
                .ThenInclude(x => x.Korisnici)
                .ThenInclude(x => x.Grad)
                .ThenInclude(x => x.Drzava).ToList();


            var userUsluge = new List<Usluga>();
            foreach (var item in pacijentoviTermini)
            {
                var obj = _mapper.Map<Usluga>(item.Usluga);
                if (userUsluge.Find(x => x.UslugaId == obj.UslugaId) == null)
                {
                    userUsluge.Add(obj);
                }
            }
            foreach (var item in pacijentoveOcjene)
            {
                var obj = _mapper.Map<Usluga>(item.Usluga);
                if (userUsluge.Find(x => x.UslugaId == obj.UslugaId) == null)
                {
                    userUsluge.Add(obj);
                }
            }
            foreach (var item in pacijentovePretplate)
            {
                var obj = _mapper.Map<Usluga>(item.Usluga);
                if (userUsluge.Find(x => x.UslugaId == obj.UslugaId) == null)
                {
                    userUsluge.Add(obj);
                }
            }

            var allEvents = _mapper.Map<List<Usluga>>((_context.Uslugas.ToList()));

            foreach (var item in userUsluge)
            {
                if (pacijentoviTermini.Find(x => x.UslugaId == item.UslugaId) != null)
                {
                    allEvents.RemoveAll(x => x.UslugaId == item.UslugaId);
                }
            }

            var eventsWithScore = new List<ItemScore<Usluga>>();
            foreach (var item in allEvents)
            {
                var newItem = new ItemScore<Usluga>
                {
                    Item = item,
                    Score = 0
                };
                eventsWithScore.Add(newItem);
            }

            foreach (var item in eventsWithScore)
            {
                foreach (var userItem in userUsluge)
                {
                    item.Score += _cbf.CalculateSimilarity(_wordGenerator.GenerateWordBag<Usluga>(item.Item),
                        _wordGenerator.GenerateWordBag<Usluga>(userItem));
                }
            }

            eventsWithScore.Sort((a, b) => b.Score.CompareTo(a.Score));
            var recommendedEvents = new List<Usluga>();
            foreach (var item in eventsWithScore)
            {
                recommendedEvents.Add(item.Item);
            }

            return recommendedEvents.Take(5).ToList();
        }
    }
}