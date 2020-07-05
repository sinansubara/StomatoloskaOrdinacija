using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    public class Materijali
    {
        [Key] 
        public int MaterijaliId { get; set; }

        [ForeignKey(nameof(Skladiste))]
        public int SkladisteId { get; set; }
        public Skladiste Skladiste { get; set; }

        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,1)")]
        public decimal Kolicina { get; set; }

        [Required]
        [Column(TypeName = "SMALLDATETIME")]
        public DateTime Datum { get; set; }
    }
}
