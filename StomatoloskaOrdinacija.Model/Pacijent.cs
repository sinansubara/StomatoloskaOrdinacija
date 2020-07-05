using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Pacijent
    {
        public int PacijentId { get; set; }

        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }
        public bool AlergijaNaLijek { get; set; }
        public bool Proteza { get; set; }
        public bool Terapija { get; set; }
        public bool Navlake { get; set; }
        public bool Aparatic { get; set; }
    }
}
