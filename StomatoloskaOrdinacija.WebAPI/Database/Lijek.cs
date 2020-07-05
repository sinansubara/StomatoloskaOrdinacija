using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("Lijek")]
    public class Lijek
    {
        [Key]
        public int LijekId { get; set; }

        [Required]
        [StringLength(70)]
        public string Naziv { get; set; }
    }
}