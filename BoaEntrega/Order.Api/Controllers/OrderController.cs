using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Model.Request;
using Order.Api.Model.Response;
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
        [ProducesResponseType(typeof(OrderCreateResponse), 200)]
        [ProducesResponseType(typeof(string), 422)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderRequest request)
        {
            try
            {
                var warehouse = _mapper.Map<OrderModel>(request);
                var result = await _orderService.CreateAsync(warehouse);
                return Ok(_mapper.Map<OrderCreateResponse>(result));
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

        [Route("status/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(OrderStatusResponse), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetByDateAsync(Guid id)
        {
            try
            {
                var result = await _orderService.GetByIdAsync(id);
                return Ok(_mapper.Map<OrderStatusResponse>(result));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("period")]
        [HttpGet]
        [ProducesResponseType(typeof(OrderModel), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GetByDateAsync([FromQuery]DateTime start, [FromQuery] DateTime end)
        {
            try
            {
                var result = await _orderService.GetOrderByPeriodAsync(start, end);
                return Ok(_mapper.Map<OrderStatusResponse>(result));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("carriage/{id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(OrderCreateResponse), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> SetOnCarriageAsync(Guid id)
        {
            try
            {
                var result = await _orderService.UpdateStatusAsync(id, OrderStatus.OnCarriage);
                return Ok(_mapper.Map<OrderStatusResponse>(result));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [Route("finish/{id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(OrderCreateResponse), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> SetReadyAsync(Guid id)
        {
            try
            {
                var result = await _orderService.UpdateStatusAsync(id, OrderStatus.Ready);
                return Ok(_mapper.Map<OrderStatusResponse>(result));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("canceled/{id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(OrderCreateResponse), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> SetCanceledAsync(Guid id)
        {
            try
            {
                var result = await _orderService.UpdateStatusAsync(id, OrderStatus.Canceled);
                return Ok(_mapper.Map<OrderStatusResponse>(result));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
