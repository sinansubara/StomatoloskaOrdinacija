using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class UlazUSkladisteInsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }

        [Required]
        [StringLength(50)]
        public string BrojFakture { get; set; }

        [Required]
        public decimal IznosRacuna { get; set; }
    }
}
