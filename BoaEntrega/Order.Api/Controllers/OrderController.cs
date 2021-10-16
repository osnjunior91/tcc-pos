using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Model.Request;
using Order.Lib.Infrastructure.Data;
using Order.Lib.Services;
using System;
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
            try
            {
                var warehouse = _mapper.Map<OrderModel>(request);
                var result = await _orderService.CreateAsync(warehouse);
                return Ok(result);
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

        [Route("period")]
        [HttpGet]
        public async Task<IActionResult> GetByDateAsync([FromQuery]DateTime start, [FromQuery] DateTime end)
        {
            try
            {
                var result = await _orderService.GetOrderByPeriodAsync(start, end);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("carriage/{id}")]
        [HttpPatch]
        public async Task<IActionResult> SetOnCarriageAsync(Guid id)
        {
            try
            {
                var result = await _orderService.UpdateStatusAsync(id, OrderStatus.OnCarriage);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [Route("finish/{id}")]
        [HttpPatch]
        public async Task<IActionResult> SetReadyAsync(Guid id)
        {
            try
            {
                var result = await _orderService.UpdateStatusAsync(id, OrderStatus.Ready);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("canceled/{id}")]
        [HttpPatch]
        public async Task<IActionResult> SetCanceledAsync(Guid id)
        {
            try
            {
                var result = await _orderService.UpdateStatusAsync(id, OrderStatus.Canceled);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
