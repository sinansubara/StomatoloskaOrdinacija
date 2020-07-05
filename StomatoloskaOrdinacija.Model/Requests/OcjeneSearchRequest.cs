using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class OcjeneSearchRequest
    {
        public int PacijentId { get; set; }
        public int UslugaId { get; set; }
        public int MjesecOcjene { get; set; }
        public int GodinaOcjene { get; set; }
        public decimal Ocjena { get; set; }
        public string Komentar { get; set; }
    }
}
