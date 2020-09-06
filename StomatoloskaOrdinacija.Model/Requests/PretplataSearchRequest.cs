using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class PretplataSearchRequest
    {
        public int UslugaId { get; set; }
        public int PacijentId { get; set; }
        public int Dan { get; set; }
        public int Mjesec { get; set; }
        public int Godina { get; set; }
        public string IsNaSnizenju { get; set; }
    }
}
