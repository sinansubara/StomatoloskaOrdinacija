using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("UlazUSkladiste")]
    public class UlazUSkladiste
    {
        [Key]
        public int UlazUSkladisteID { get; set; }

        [ForeignKey(nameof(Korisnici))]
        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }

        [Required]
        [StringLength(50)]
        public string BrojFakture { get; set; }

        [Required]
        [Column(TypeName = "SMALLDATETIME")]
        public DateTime Datum { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal IznosRacuna { get; set; }

    }
}