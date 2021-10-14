using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Model.Request;
using Order.Lib.Infrastructure.Data;
using Order.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderRequest request)
        {
            var warehouse = _mapper.Map<OrderModel>(request);
            var result = await _orderService.CreateAsync(warehouse);
            return Ok(result);
        }
    }
}
