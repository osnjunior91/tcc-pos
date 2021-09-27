using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Model.Request;
using Product.Lib.Infrastructure.Data;
using Product.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var warehouse = _mapper.Map<ProductModel>(request);
            var result = await _productService.CreateAsync(warehouse);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = await _productService.GetByIdAsync(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
