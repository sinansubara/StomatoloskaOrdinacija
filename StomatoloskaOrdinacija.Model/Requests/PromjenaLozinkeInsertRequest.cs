using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class PromjenaLozinkeInsertRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
