using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kolEF.DTOs.Requests
{
    public class AddOrderRequest
    {
        [Required]
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        public string Uwagi { get; set; }

        [Required]
        public string Wyrob { get; set; }

        [Required]
        public int Ilosc { get; set; }
        public string WyrobUwagi { get; set; }


    }
}
