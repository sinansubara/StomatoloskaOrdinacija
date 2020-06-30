﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Korisnici
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public bool? Status { get; set; }

        public int Index { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}
