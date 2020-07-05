using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("Termini")]
    public class Termin
    {
        [Key]
        public int TerminId { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

        [ForeignKey(nameof(Usluga))]
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DatumVrijeme { get; set; }

        [Required]
        [StringLength(200)]
        public string Razlog { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool Hitan { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsOdobren { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsNaCekanju { get; set; }
    }
}