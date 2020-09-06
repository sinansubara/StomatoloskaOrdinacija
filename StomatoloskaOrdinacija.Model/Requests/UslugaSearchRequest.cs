using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class UslugaSearchRequest
    {
        public string Naziv { get; set; }
        public int PacijentId { get; set; }
        public string IsPretplacen { get; set; }
    }
}
