using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("Usluga")]
    public class Usluga
    {
        [Key]
        public int UslugaId { get; set; }

        [Required]
        [StringLength(150)]
        public string Naziv { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Cijena { get; set; }
    }
}