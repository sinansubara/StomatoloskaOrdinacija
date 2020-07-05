using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("Skladiste")]
    public class Skladiste
    {
        [Key]
        public int SkladisteId { get; set; }

        [ForeignKey(nameof(UlazUSkladiste))]
        public int UlazUSkladisteId { get; set; }
        public UlazUSkladiste UlazUSkladiste { get; set; }

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
        [Column(TypeName = "DECIMAL(18,1)")]
        public decimal Kolicina { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Mjerna jedinica")]
        public string MjernaJedinica { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Cijena { get; set; }

        public byte[] Slika { get; set; }

    }
}