using Customer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController1 : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] CustomerCreateRequest customer)
        {
        }
    }
}
