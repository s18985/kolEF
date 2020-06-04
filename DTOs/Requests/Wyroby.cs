using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kolEF.DTOs.Requests
{
    public class Wyroby
    {
        [Required]
        public string Wyrob { get; set; }

        [Required]
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }

    }
}
