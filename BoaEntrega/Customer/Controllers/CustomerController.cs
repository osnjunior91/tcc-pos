using AutoMapper;
using Customer.Lib.Infrastructure.Data.Model;
using Customer.Lib.Services;
using Customer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Customer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerCreateRequest request)
        {
            var customer = _mapper.Map<CustomerModel>(request);
            var result = await _customerService.CreateAsync(customer);
            return Ok(result);
        }
    }
}
