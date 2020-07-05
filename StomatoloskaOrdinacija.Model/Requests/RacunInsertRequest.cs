using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class RacunInsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        [Required]
        public int PregledId { get; set; }
    }
}
