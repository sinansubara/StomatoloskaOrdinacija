using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Korisnici
    {
        
        public int KorisnikId { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }
        
        public string Email { get; set; }

        public string KorisnickoIme { get; set; }

        public string JMBG { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public string Mobitel { get; set; }

        public string Adresa { get; set; }

        public int GradId { get; set; }
        public Grad Grad { get; set; }
        
        public string Spol { get; set; }

        public bool Status { get; set; }
        public byte[] Slika { get; set; }

        public Uloge Uloga { get; set; }
        public int UlogaId { get; set; }
        public int obavljenoPregleda { get; set; }

        public string ImeIPrezime => Ime + " " + Prezime;
        public decimal UkupnoNovca { get; set; }
    }
}
