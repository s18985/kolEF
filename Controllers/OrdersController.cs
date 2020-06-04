using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolEF.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolEF.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private ICakeDbService _service;

        public OrdersController(ICakeDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetOrders(string nazwisko)
        {
            var res = _service.GetOrders(nazwisko);

            if (res.Count() != 0)
            {
                return Ok(res);
            }
            else
            {
                return NotFound("Nie ma takiego klienta");
            }
        }

    }
}