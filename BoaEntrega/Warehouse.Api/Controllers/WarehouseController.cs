using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Api.Model.Request;
using Warehouse.Api.Model.Response;
using Warehouse.Lib.Infrastructure.Data;
using Warehouse.Lib.Services;

namespace Warehouse.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;
        public WarehouseController(IWarehouseService warehouseService, IMapper mapper)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] WarehouseCreateRequest request)
        {
            var warehouse = _mapper.Map<WarehouseModel>(request);
            var result = await _warehouseService.CreateAsync(warehouse);
            return Ok(_mapper.Map<WarehouseCreateResponse>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = await _warehouseService.GetByIdAsync(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _warehouseService.GetAllAsync();
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _warehouseService.DeleteAsync(id);
            return Ok();
        }

    }
}
