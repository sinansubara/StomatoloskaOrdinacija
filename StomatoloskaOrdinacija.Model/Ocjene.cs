using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Ocjene
    {
        public int OcjenaId { get; set; }

        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }
        public DateTime Kreirano { get; set; }
        public decimal Ocjena { get; set; }
        public string Komentar { get; set; }
    }
}
