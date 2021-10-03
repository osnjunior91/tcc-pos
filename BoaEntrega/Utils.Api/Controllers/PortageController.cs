using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utils.Api.Model.Request;

namespace Utils.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortageController : ControllerBase
    {
        [Route("price")]
        [HttpGet]
        public async Task<IActionResult> GetPriceAsync([FromBody] GetPriceRequest request)
        {
            return Ok();
        }
    }
}
