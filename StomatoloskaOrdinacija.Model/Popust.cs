using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Popust
    {
        public int PopustId { get; set; }
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }
        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }
        public DateTime PopustOdDatuma { get; set; }
        public DateTime PopustDoDatuma { get; set; }
        public int VrijednostPopusta { get; set; }
    }
}
