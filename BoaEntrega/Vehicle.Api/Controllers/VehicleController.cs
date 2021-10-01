using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Data.Request;
using Vehicle.Api.Data.Response;
using Vehicle.Lib.Infrastructure.Data;
using Vehicle.Lib.Services;

namespace Vehicle.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;
        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] VehicleCreateRequest request)
        {
            var warehouse = _mapper.Map<VehicleModel>(request);
            var result = await _vehicleService.CreateAsync(warehouse);
            return Ok(_mapper.Map<VehicleCreateResponse>(result));
        }
    }
}
