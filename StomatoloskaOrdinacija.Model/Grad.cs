using System;
using System.Collections.Generic;
using System.Text;

namespace StomatoloskaOrdinacija.Model
{
    public class Grad
    {
        public int GradId { get; set; }

        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
    }
}
