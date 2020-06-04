using kolEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolEF.DTOs.Responses
{
    public class AddOrderResponse
    {
        public string NazwaWyrobu { get; set; }
        public Zamowienie Zamowienie { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }


    }
}
