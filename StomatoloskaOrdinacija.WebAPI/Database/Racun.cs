using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("Racun")]
    public class Racun
    {
        [Key]
        public int RacunId { get; set; }

        [ForeignKey(nameof(Korisnici))]
        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }

        [ForeignKey(nameof(Pregled))]
        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal UkupnaCijena { get; set; }

        [Required]
        [Column(TypeName = "SMALLDATETIME")]
        [Display(Name = "Datum izdavanja racuna")]
        public DateTime DatumIzdavanjaRacuna { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsPlatio { get; set; }
    }
}