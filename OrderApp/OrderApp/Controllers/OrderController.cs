using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApp.DataTransferObjects;
using OrderApp.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController (IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }


        //Get a order
        ///<param name="orderId"></param>
        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(OrderResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetOrder([FromRoute] int orderId)
        {
            var order = _orderService.GetOrder(orderId);
            if(order == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<OrderResponseDto>(order);
            return Ok(result);
        }
        //Get a list of all orders
        [HttpGet]
        [ProducesResponseType(typeof(List<OrderResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetOrders();
            if(!orders.Any())
            {
                return NoContent();
            }

            var result = _mapper.Map<List<OrderResponseDto>>(orders);
            return Ok(result);
        }

        //Creates an order
        /// <param name="orderRequestDto"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateOrder(OrderRequestDto orderRequestDto)
        {
            var order = _orderService.CreateOrder(orderRequestDto);
            if(!order)
            {
                return BadRequest();
            }
            return Created("", null);
        }

        //Edit a order
        /// <param name="orderId"></param>
        /// /// <param name="orderRequestDto"></param>
        [HttpPut("{orderId}")]
        [ProducesResponseType(typeof(OrderResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult EditOrder([FromRoute] int orderId, [FromBody] OrderRequestDto orderRequestDto)
        {
            var editOrder = _orderService.EditOrder(orderId, orderRequestDto);
            if(editOrder == null)
            {
                return UnprocessableEntity();
            }

            var result = _mapper.Map<OrderResponseDto>(editOrder);
            return Ok(result);
        }

        ///Delete a order
        /// <param name="orderId"></param>
        [HttpDelete("{orderId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult DeleteOrder([FromRoute] int orderId)
        {
            var deleteOrder = _orderService.DeleteOrder(orderId);
            if(!deleteOrder)
            {
                return UnprocessableEntity();
            }

            return Ok(deleteOrder);
        }
    }
}
