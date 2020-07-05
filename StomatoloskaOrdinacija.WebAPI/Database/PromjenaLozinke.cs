using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    public class PromjenaLozinke
    {
        [Key]
        public int PromjenaLozinkeID { get; set; }

        [Required]
        [StringLength(30)]
        public string Vrijednost { get; set; }

        [ForeignKey(nameof(Korisnici))]
        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }

        [Required]
        [Column(TypeName = "SMALLDATETIME")]
        [Display(Name = "Datum promjene")]
        public DateTime DatumPromjene { get; set; }
    }

}
