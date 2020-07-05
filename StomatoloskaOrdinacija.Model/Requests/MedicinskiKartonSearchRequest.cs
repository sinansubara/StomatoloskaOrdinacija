using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class MedicinskiKartonSearchRequest
    {
        public int PregledId { get; set; }

        public int PacijentId { get; set; }
        public int Dan { get; set; }
        public int Mjesec { get; set; }
        public int Godina { get; set; }

    }
}
