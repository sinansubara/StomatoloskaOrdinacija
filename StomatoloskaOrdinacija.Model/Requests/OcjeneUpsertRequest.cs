using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class OcjeneUpsertRequest
    {
        [Required]
        public int PacijentId { get; set; }
        [Required]
        public int UslugaId { get; set; }

        [Required]
        [Range(1,10,ErrorMessage = "Ocjena mora biti od 1 do 10!")]
        public decimal Ocjena { get; set; }

        [Required]
        [StringLength(300)]
        public string Komentar { get; set; }
    }
}
