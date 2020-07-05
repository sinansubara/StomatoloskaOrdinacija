using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class KorisniciUpdateRequest
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

        [StringLength(30)]
        [Required(AllowEmptyStrings = false)]
        public string Mobitel { get; set; }

        [StringLength(200)]
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Adresa { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [StringLength(13,MinimumLength = 13,ErrorMessage = "JMBG mora da ima 13 brojeva!")]
        [Required]
        public string JMBG { get; set; }

        public bool? Status { get; set; }
        public byte[] Slika { get; set; }
        [Required]
        public int GradId { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public int UlogaId { get; set; }

    }
}
