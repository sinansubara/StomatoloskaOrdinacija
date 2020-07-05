using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StomatoloskaOrdinacija.Model.Requests
{
    public class RacunUpdateRequest
    {
        [Required]
        public bool IsPlatio { get; set; }
    }
}
