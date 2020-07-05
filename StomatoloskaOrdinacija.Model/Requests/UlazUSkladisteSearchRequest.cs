using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class UlazUSkladisteSearchRequest
    {
        public int KorisnikId { get; set; }
        public string BrojFakture { get; set; }
        public int Godina { get; set; }
        public int Mjesec { get; set; }
        public int Dan { get; set; }
    }
}
