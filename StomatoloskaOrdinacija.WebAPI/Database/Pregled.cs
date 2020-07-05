using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("Pregledi")]
    public class Pregled
    {
        [Key]
        public int PregledId { get; set; }

        [ForeignKey(nameof(Korisnici))]
        public int KorisnikId { get; set; }
        public Korisnici Korisnici { get; set; }

        [ForeignKey(nameof(Termin))]
        public int TerminId { get; set; }
        public Termin Termin { get; set; }

        [ForeignKey(nameof(Lijek))]
        public int LijekId { get; set; }
        public Lijek Lijek { get; set; }

        [ForeignKey(nameof(Dijagnoza))]
        public int DijagnozaId { get; set; }
        public Dijagnoza Dijagnoza { get; set; }

        [ForeignKey(nameof(Skladiste))]
        public int SkladisteId { get; set; }
        public Skladiste Skladiste { get; set; }

        [Required]
        [Column(TypeName = "SMALLINT")]
        [Display(Name = "Trajanje pregleda")]
        public int TrajanjePregleda { get; set; }

        [Required]
        [StringLength(200)]
        public string Napomena { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18,1)")]
        public decimal KolicinaOdabranogMaterijala { get; set; }

    }
}