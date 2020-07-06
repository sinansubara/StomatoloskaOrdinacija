using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Skladiste
    {
        public int SkladisteId { get; set; }
        public int UlazUSkladisteId { get; set; }
        public UlazUSkladiste UlazUSkladiste { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Vrsta { get; set; }
        public string Proizvodjac { get; set; }
        public decimal Kolicina { get; set; }
        public string MjernaJedinica { get; set; }
        public decimal Cijena { get; set; }
        public byte[] Slika { get; set; }

        public string NazivVrsta => Naziv + "           " + Vrsta;
    }
}
