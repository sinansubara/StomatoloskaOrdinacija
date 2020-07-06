using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class TerminSearchRequest
    {
        public int PacijentId { get; set; }
        public int UslugaId { get; set; }
        public int Mjesec { get; set; }
        public int Godina { get; set; }
        public bool IsNaCekanju { get; set; }
        public string IsIskoristenRequest { get; set; }
    }
}
