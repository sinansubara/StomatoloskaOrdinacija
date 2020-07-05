using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class KorisniciInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string KorisnickoIme { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(13, MinimumLength = 13)]
        public string JMBG { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Mobitel { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Adresa { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string PasswordPotvrda { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10)]
        public string Spol { get; set; }

        public bool? Status { get; set; }
        public byte[] Slika { get; set; }


        [Required]
        public int UlogaId { get; set; }
        [Required]
        public int GradId { get; set; }
    }
}
