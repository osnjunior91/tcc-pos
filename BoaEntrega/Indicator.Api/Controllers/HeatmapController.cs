using Indicator.Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeatmapController : ControllerBase
    {
        private readonly IIndicatorService _indicatorService;
        public HeatmapController(IIndicatorService indicatorService)
        {
            _indicatorService = indicatorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            try
            {
                var result = await _indicatorService.GetByPeriodAsync(start, end);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
