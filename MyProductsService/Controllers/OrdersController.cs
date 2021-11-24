using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProductsService
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder(List<OrderItem> OrderItems)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("query")]
        public async Task<IActionResult> GetOrderByQueryString(string query)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PayOrder(Guid orderId)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id,List<OrderItem>orderItems)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("take")]
        public async Task<IActionResult> TakeOrder(Guid id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("cancel")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
