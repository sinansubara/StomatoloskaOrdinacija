using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("MedicinskiKarton")]
    public class MedicinskiKarton
    {
        [Key] 
        public int MedicinskiKartonId { get; set; }

        [ForeignKey(nameof(Pregled))]
        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }

        [Required]
        [StringLength(200)]
        public string Napomena { get; set; }
    }
}