using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Usluga
    {
        public int UslugaId { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public decimal SumaCijena { get; set; }
    }
}
