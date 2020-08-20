using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.Model
{
    public class PromjenaLozinke
    {
        public int PromjenaLozinkeID { get; set; }

        public string Vrijednost { get; set; }

        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }

        public DateTime DatumPromjene { get; set; }
    }

}
