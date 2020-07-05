using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class KorisnikPacijent
    {
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
