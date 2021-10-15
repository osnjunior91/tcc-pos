using AutoMapper;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Api.Model.Request;
using Utils.Lib.Services;

namespace Utils.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        private readonly IGeoService _geoService;
        private readonly IMapper _mapper;
        public GeoController(IGeoService geoService, IMapper mapper)
        {
            _geoService = geoService;
            _mapper = mapper;
        }

        [Route("distance")]
        [HttpPost]
        public async Task<IActionResult> GetDistanceAsync([FromBody] GetDistanceRequest request)
        {
            return Ok(await _geoService.GetDistanceAsync(_mapper.Map<AddressModel>(request.From), _mapper.Map<AddressModel>(request.To)));
        }

        [Route("coordinates")]
        [HttpPost]
        public async Task<IActionResult> GetCoordinatesAsync([FromBody] AddressRequest request)
        {
            return Ok(await _geoService.GetCordinatesByAddress(_mapper.Map<AddressModel>(request)));
        }
    }
}
