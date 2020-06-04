using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolEF.Models
{
    public class Zamowienie
    {
        public Zamowienie()
        {
            ZamowienieWyrobCukierniczy = new HashSet<ZamowienieWyrobCukierniczy>();
        }

        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public int IdKlientt { get; set; }
        public int IdPracownikk { get; set; }


        public virtual Klientt Klientt { get; set; }
        public virtual Pracownikk Pracownikk { get; set; }
        public virtual ICollection<ZamowienieWyrobCukierniczy> ZamowienieWyrobCukierniczy { get; set; }

    }
}
