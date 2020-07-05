using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class GradUpsertRequest
    {
        [Required]
        public int DrzavaId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Naziv { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(20)] 
        public string PostanskiBroj { get; set; }
    }
}
