using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class SkladisteInsertRequest
    {
        [Required]
        public int UlazUSkladisteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(300)]
        public string Opis { get; set; }

        [Required]
        [StringLength(100)]
        public string Vrsta { get; set; }

        [Required]
        [StringLength(100)]
        public string Proizvodjac { get; set; }

        [Required]
        public decimal Kolicina { get; set; }

        [Required]
        [StringLength(20)]
        public string MjernaJedinica { get; set; }

        [Required]
        public decimal Cijena { get; set; }

        public byte[] Slika { get; set; }
    }
}
