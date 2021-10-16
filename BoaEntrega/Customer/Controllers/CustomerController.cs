using AutoMapper;
using Customer.Lib.Infrastructure.Data.Model;
using Customer.Lib.Services;
using Customer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            try
            {
                var customer = _mapper.Map<CustomerModel>(request);
                var result = await _customerService.CreateAsync(customer);
                return Ok(_mapper.Map<CustomerResponse>(result));
            }
            catch (ValidationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var response = await _customerService.GetByIdAsync(id);
                if (response == null)
                    return NotFound();
                return Ok(_mapper.Map<CustomerResponse>(response));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _customerService.GetAllAsync();
                if (response == null)
                    return NotFound();
                return Ok(_mapper.Map<List<CustomerResponse>>(response));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
