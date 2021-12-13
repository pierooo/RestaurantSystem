using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class OrdersController : ApiControllerBase
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllOrders([FromQuery] GetOrdersRequest request)
        {
            return this.HandleRequest<GetOrdersRequest, GetOrdersResponse>(request);
        }
        [HttpGet]
        [Route("{orderId}")]
        public Task<IActionResult> GetOrderById([FromRoute] int orderId)
        {
            var request = new GetOrderByIdRequest()
            {
                OrderID = orderId
            };
            return this.HandleRequest<GetOrderByIdRequest, GetOrderByIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddOrder([FromBody] AddOrderRequest request)
        {
            return this.HandleRequest<AddOrderRequest, AddOrderResponse>(request);
        }
        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutOrder([FromBody] PutOrderRequest request)
        {
            return this.HandleRequest<PutOrderRequest, PutOrderResponse>(request);
        }
        [HttpDelete]
        [Route("{orderId}")]
        public Task<IActionResult> DeleteOrder([FromRoute] int orderId)
        {
            var request = new DeleteOrderRequest()
            {
                OrderID = orderId
            };
            return this.HandleRequest<DeleteOrderRequest, DeleteOrderResponse>(request);
        }
    }
}
