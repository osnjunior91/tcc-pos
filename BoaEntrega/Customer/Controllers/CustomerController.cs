using AutoMapper;
using Customer.Lib.Infrastructure.Data.Model;
using Customer.Lib.Services;
using Customer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            return Ok(_mapper.Map<CustomerResponse>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = await _customerService.GetByIdAsync(id);
            if (response == null)
                return NotFound();
            return Ok(_mapper.Map<CustomerResponse>(response));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerService.GetAllAsync();
            if (response == null)
                return NotFound();
            return Ok(_mapper.Map<List<CustomerResponse>>(response));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _customerService.DeleteAsync(id);
            return Ok();
        }
    }
}
