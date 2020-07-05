using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    public class Uloge
    {
        [Key]
        public int UlogaId { get; set; }

        [StringLength(100)]
        [Required]
        public string Naziv { get; set; }

        [StringLength(200)]
        [Required]
        public string Opis { get; set; }
    }
}
