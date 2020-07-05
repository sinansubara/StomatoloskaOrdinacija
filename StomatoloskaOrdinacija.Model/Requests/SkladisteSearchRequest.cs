using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class SkladisteSearchRequest
    {
        public string Naziv { get; set; }
        public string Vrsta { get; set; }
        public string Proizvodjac { get; set; }
    }
}
