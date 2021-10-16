using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Model.Request;
using Product.Lib.Infrastructure.Data;
using Product.Lib.Services;
using System;
using System.Threading.Tasks;

namespace Product.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductCreateRequest request)
        {
            try
            {
                var warehouse = _mapper.Map<ProductModel>(request);
                var result = await _productService.CreateAsync(warehouse);
                return Ok(result);
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
                var response = await _productService.GetByIdAsync(id);
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [Route("amount/{id}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateAmountAsync(Guid id, [FromBody] UpdateAmountRequest amount)
        {
            try
            {
                await _productService.UpdateAmountAsync(id, amount.Amount);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
    }
}
