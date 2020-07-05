using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class PopustInsertRequest
    {
        [Required]
        public int UslugaId { get; set; }
        [Required]
        public int KorisnikId { get; set; }

        [Required]
        public DateTime PopustOdDatuma { get; set; }

        [Required]
        public DateTime PopustDoDatuma { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Unesite popust od 1 do 100!")]
        public int VrijednostPopusta { get; set; }
    }
}
