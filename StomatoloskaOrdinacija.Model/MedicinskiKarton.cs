using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class MedicinskiKarton
    {
        public int MedicinskiKartonId { get; set; }

        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }

        
        public string ImePacijenta { get; set; }
        public string ImeUsluge { get; set; }
        public decimal Cijena { get; set; }

        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

        public DateTime Datum { get; set; }
        public string Napomena { get; set; }
        
    }
}
