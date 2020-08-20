using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Pregled
    {
        public int PregledId { get; set; }

        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }
        public string DoktorIme { get; set; }

        public int TerminId { get; set; }
        public Termin Termin { get; set; }
        public string TerminImePacijenta { get; set; }
        public string TerminRazlog { get; set; }
        public string TerminZavrsen { get; set; }

        public int LijekId { get; set; }
        public Lijek Lijek { get; set; }
        public string LijekTekst { get; set; }

        public int DijagnozaId { get; set; }
        public Dijagnoza Dijagnoza { get; set; }
        public string DijagnozaTekst { get; set; }

        public int SkladisteId { get; set; }
        public Skladiste Skladiste { get; set; }
        public string Materijal { get; set; }

        public int TrajanjePregleda { get; set; }
        public string Napomena { get; set; }
        public decimal KolicinaOdabranogMaterijala { get; set; }
        public string PregledIme { get; set; }
    }
}
