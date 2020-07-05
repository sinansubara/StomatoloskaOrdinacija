using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Pretplata
    {
        public int PretplataId { get; set; }
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
        public DateTime DatumPretplate { get; set; }
        public bool IsAktivna { get; set; }
    }
}
