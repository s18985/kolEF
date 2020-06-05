using kolEF.DTOs.Requests;
using kolEF.DTOs.Responses;
using kolEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolEF.DAL
{
    public class EFServerDbService : ICakeDbService
    {
        private CodeFirstContext _context;

        public EFServerDbService(CodeFirstContext context)
        {
            _context = context;
        }

        public AddOrderResponse AddOrder(int id, AddOrderRequest request)
        {
            int maxIdZam = _context.Zamowienie.Max(x => x.IdZamowienia);

            var NoweZam = new Zamowienie
            {
                IdZamowienia = (maxIdZam + 1),
                DataPrzyjecia = request.DataPrzyjecia,
                DataRealizacji = request.DataRealizacji,
                Uwagi = request.Uwagi,
                IdKlientt = id,
                IdPracownikk = 1
            };

            _context.Zamowienie.Add(NoweZam);

            List <WyrobDTO> wyroby = new List<WyrobDTO>(request.Wyroby);

            foreach(WyrobDTO w in wyroby){

                var a = _context.WyrobCukierniczy.Where(x => x.Nazwa == w.Wyrob).FirstOrDefault();
                if (a == null)
                {
                    return null;
                }
                else
                {
                    var order2 = _context.ZamowienieWyrobCukierniczy.Add(new ZamowienieWyrobCukierniczy
                    {
                        IdWyrobuCukierniczego = a.IdWyrobuCukierniczego,
                        IdZamowienia = NoweZam.IdZamowienia,
                        Ilosc = w.Ilosc,
                        Uwagi = w.Uwagi
                    });
                }
            }

            _context.SaveChanges();

                var res = new AddOrderResponse
                {
                    Zamowienie = NoweZam
                };

                return res;
            
        }

        public List<Zamowienie> GetOrders(string nazwisko)
        {

            if (nazwisko == null)
            {
                var res = _context.Zamowienie.Include(x => x.ZamowienieWyrobCukierniczy).ThenInclude(x => x.WyrobCukierniczy).ToList();
                return res;
            }
            else
            {
                var klient = _context.Klientt.Where(x => x.Nazwisko == nazwisko).Select(x => x.IdKlientt).FirstOrDefault();
                var res = _context.Zamowienie.Where(x => x.IdKlientt == klient).Include(x => x.ZamowienieWyrobCukierniczy).ThenInclude(x => x.WyrobCukierniczy).ToList();
                return res;
            }
        }
    }
}
