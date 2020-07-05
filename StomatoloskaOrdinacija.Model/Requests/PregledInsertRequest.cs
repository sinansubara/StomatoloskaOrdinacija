using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class PregledInsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        [Required]
        public int TerminId { get; set; }
        [Required]
        public int LijekId { get; set; }
        [Required]
        public int DijagnozaId { get; set; }
        [Required]
        public int SkladisteId { get; set; }

        [Required]
        [Range(1,480, ErrorMessage = "Trajanje pregleda ne moze biti manje od 1 minute i vece od 480 minuta")]
        public int TrajanjePregleda { get; set; }

        [Required]
        [StringLength(200)]
        public string Napomena { get; set; }
        [Required]
        public decimal KolicinaOdabranogMaterijala { get; set; }
    }
}
