using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolEF.Models
{
    public class Klientt
    {
        public Klientt()
        {
            Zamowienia = new HashSet<Zamowienie>();
        }

        public int IdKlientt { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public virtual ICollection<Zamowienie> Zamowienia { get; set; }

    }
}
