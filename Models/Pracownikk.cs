using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolEF.Models
{
    public class Pracownikk
    {
        public Pracownikk()
        {
            Zamowienia = new HashSet<Zamowienie>();
        }

        public int IdPracownikk { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public virtual ICollection<Zamowienie> Zamowienia { get; set; }

    }
}
