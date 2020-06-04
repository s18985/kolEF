using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolEF.DAL;
using kolEF.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolEF.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private ICakeDbService _service;

        public ClientsController(ICakeDbService service)
        {
            _service = service;
        }


        [HttpPost("{id}/orders")]
        public IActionResult AddOrder(int id, AddOrderRequest request)
        {
            var res = _service.AddOrder(id, request);

            if (res == null)
            {
                return BadRequest("Nie ma takiego wyrobu");
            }
            else
            {
                return Ok(res);
            }
        }


    }
}