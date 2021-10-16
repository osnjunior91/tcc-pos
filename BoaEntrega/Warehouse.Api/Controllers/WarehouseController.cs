using AutoMapper;
using FluentValidation;
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
            try
            {
                var warehouse = _mapper.Map<WarehouseModel>(request);
                var result = await _warehouseService.CreateAsync(warehouse);
                return Ok(_mapper.Map<WarehouseCreateResponse>(result));
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
                var response = await _warehouseService.GetByIdAsync(id);
                if (response == null)
                    return NotFound();
                return Ok(response);
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
                var response = await _warehouseService.GetAllAsync();
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            
            try
            {
                await _warehouseService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
