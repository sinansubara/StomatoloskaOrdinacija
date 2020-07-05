using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class GradSearchRequest
    {
        public int DrzavaId { get; set; }

        public string Naziv { get; set; }

        public string PostanskiBroj { get; set; }
    }
}
