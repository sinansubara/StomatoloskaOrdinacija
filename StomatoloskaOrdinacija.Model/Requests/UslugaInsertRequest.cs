using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class UslugaInsertRequest
    {
        [Required]
        [StringLength(150)]
        public string Naziv { get; set; }

        [Required]
        public decimal Cijena { get; set; }
    }
}
