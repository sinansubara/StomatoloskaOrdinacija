using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Termin
    {
        public int TerminId { get; set; }
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
        public string PacijentIme { get; set; }
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }
        public string UslugaNaziv { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Razlog { get; set; }
        public bool Hitan { get; set; }
        public bool IsOdobren { get; set; }
        public bool IsNaCekanju { get; set; }

        public string UslugaIme { get; set; }
    }
}
