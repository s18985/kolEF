using kolEF.DTOs.Requests;
using kolEF.DTOs.Responses;
using kolEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolEF.DAL
{
    public interface ICakeDbService
    {

        public List<Zamowienie> GetOrders(string nazwisko);

        public AddOrderResponse AddOrder(int id, AddOrderRequest request);

    }
}
