using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class RacunSearchRequest
    {
        public int RacunId { get; set; }
        public int KorisnikId { get; set; }
        public int PregledId { get; set; }
        public int Dan { get; set; }
        public int Mjesec { get; set; }
        public int Godina { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool NijeUplatioRequest { get; set; }
    }
}
