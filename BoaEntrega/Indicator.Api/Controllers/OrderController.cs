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
    public class OrderController : ControllerBase
    {
        private readonly IIndicatorService _indicatorService;
        public OrderController(IIndicatorService indicatorService)
        {
            _indicatorService = indicatorService;
        }

        [Route("delayed")]
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var result = await _indicatorService.GetOrderDelayedAsync(start, end);
            return Ok(result);
        }
    }
}
