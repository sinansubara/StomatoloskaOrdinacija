﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    [Table("Korisnici")]
    public class Korisnici
    {
        [Key]
        public int KorisnikId { get; set; }

        [StringLength(100)]
        [Required]
        public string Ime { get; set; }

        [StringLength(100)]
        [Required]
        public string Prezime { get; set; }
        
        [StringLength(320)]
        [Required]
        [EmailAddress(ErrorMessage = "Pogrešan unos email adrese!")]
        public string Email { get; set; }

        [StringLength(100)]
        [Required]
        public string KorisnickoIme { get; set; }

        [Required]
        [StringLength(100)]
        public string LozinkaHash { get; set; }

        [Required]
        [StringLength(50)]
        public string LozinkaSalt { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Kreirano { get; set; }

        [StringLength(13,MinimumLength = 13,ErrorMessage = "JMBG mora da ima 13 brojeva!")]
        [Required]
        public string JMBG { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [StringLength(30)]
        [Required]
        public string Mobitel { get; set; }

        [StringLength(200)]
        [Required]
        public string Adresa { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }
        
        [StringLength(10)]
        [Required]
        public string Spol { get; set; }

        public byte[] Slika { get; set; }

        [ForeignKey(nameof(Uloga))]
        public int UlogaId { get; set; }
        public Uloge Uloga { get; set; }

        public bool? Status { get; set; }

    }
}
