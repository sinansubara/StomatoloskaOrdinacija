using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("Pacijenti")]
    public class Pacijent
    {
        [Key]
        public int PacijentId { get; set; }

        [ForeignKey(nameof(Korisnici))]
        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        [Display(Name = "Alergija na lijek")]
        public bool AlergijaNaLijek { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Proteza { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Terapija { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Navlake { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Aparatic { get; set; }

    }
}