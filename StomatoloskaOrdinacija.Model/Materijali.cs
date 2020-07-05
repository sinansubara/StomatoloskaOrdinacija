using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Materijali
    {
        public int MaterijaliId { get; set; }

        public int SkladisteId { get; set; }
        public Skladiste Skladiste { get; set; }
        public string Naziv { get; set; }
        public decimal Kolicina { get; set; }
        public DateTime Datum { get; set; }
        public decimal Zbir { get; set; }
    }
}
