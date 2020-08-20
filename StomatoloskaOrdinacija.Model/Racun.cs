﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Racun
    {
        public int RacunId { get; set; }

        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }
        public string RacunDoktorIme { get; set; }

        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }
        public string PregledPacijentIme { get; set; }
        public string PregledUslugaNaziv { get; set; }
        public string PregledMaterijalNaziv { get; set; }
        public string PregledMaterijalKolicina { get; set; }


        public decimal UkupnaCijena { get; set; }
        public DateTime DatumIzdavanjaRacuna { get; set; }
        public bool IsPlatio { get; set; }
    }
}
