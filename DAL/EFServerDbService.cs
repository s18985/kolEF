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
           var wyrob = _context.WyrobCukierniczy.Where(x => x.Nazwa == request.Wyrob.Wyrob).FirstOrDefault();

            if (wyrob == null)
            {
                return null;
            }
            else
            {
                var order = new Zamowienie
                {
                    DataPrzyjecia = request.DataPrzyjecia,
                    DataRealizacji = request.DataRealizacji,
                    Uwagi = request.Uwagi,
                    IdKlientt = id,
                    IdPracownikk = 1
                };

                var order2 = _context.ZamowienieWyrobCukierniczy.Add(new ZamowienieWyrobCukierniczy
                {
                    IdWyrobuCukierniczego = wyrob.IdWyrobuCukierniczego,
                    Zamowienie = order,
                    Ilosc = request.Wyrob.Ilosc,
                    Uwagi = request.Wyrob.Uwagi

                });

                var res = new AddOrderResponse
                {
                    Zamowienie = order,
                    NazwaWyrobu = wyrob.Nazwa,
                    Ilosc = request.Wyrob.Ilosc,
                    Uwagi = request.Wyrob.Uwagi

                };

                return res;
            }
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
