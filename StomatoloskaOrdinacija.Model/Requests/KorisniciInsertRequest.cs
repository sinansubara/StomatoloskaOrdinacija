using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class KorisniciInsertRequest
    {
        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [StringLength(320)]
        [Required(AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Pogrešan unos email adrese!")]
        public string Email { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string KorisnickoIme { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(13,MinimumLength = 13,ErrorMessage = "JMBG mora da ima 13 brojeva!")]
        public string JMBG { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [StringLength(30)]
        [Required(AllowEmptyStrings = false)]
        public string Mobitel { get; set; }

        [StringLength(200)]
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
