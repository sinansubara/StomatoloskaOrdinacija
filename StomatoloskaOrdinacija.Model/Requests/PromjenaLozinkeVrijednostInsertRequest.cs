using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class PromjenaLozinkeVrijednostInsertRequest
    {
        public string Vrijednost { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string PotvrdaLozinke { get; set; }
    }
}
