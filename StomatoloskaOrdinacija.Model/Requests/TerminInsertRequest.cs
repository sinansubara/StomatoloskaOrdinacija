using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class TerminInsertRequest
    {
        [Required]
        public int PacijentId { get; set; }
        [Required]
        public int UslugaId { get; set; }

        [Required]
        public DateTime DatumVrijeme { get; set; }

        [Required]
        [StringLength(200)]
        public string Razlog { get; set; }

        [Required]
        public bool Hitan { get; set; }
    }
}
