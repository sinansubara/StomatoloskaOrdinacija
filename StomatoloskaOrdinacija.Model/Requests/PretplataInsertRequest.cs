using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class PretplataInsertRequest
    {
        [Required]
        public int UslugaId { get; set; }
        [Required]
        public int PacijentId { get; set; }
        [Required]
        public bool IsAktivna { get; set; }
    }
}
