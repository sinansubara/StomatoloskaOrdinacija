using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class UlazUSkladiste
    {
        public int UlazUSkladisteID { get; set; }
        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }
        public string BrojFakture { get; set; }
        public DateTime Datum { get; set; }
        public decimal IznosRacuna { get; set; }
    }
}
