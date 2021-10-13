using AutoMapper;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utils.Api.Model.Request;
using Utils.Lib.Services;

namespace Utils.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PortageController : ControllerBase
    {
        private readonly IPortageService _portageService;
        private readonly IMapper _mapper;
        public PortageController(IPortageService portageService, IMapper mapper)
        {
            _portageService = portageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok("Parabens retornou correto");
        }

        [Route("price")]
        [HttpGet]
        public async Task<IActionResult> GetPriceAsync([FromBody] GetPriceRequest request)
        {
            return Ok(await _portageService.GetPriceAsync(request.UserId, request.WarehouseId, request.Weight));
        }
    }
}
