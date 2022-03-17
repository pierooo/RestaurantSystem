using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.Controllers
{
    [Authorize]
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
        [Route("{ID}")]
        public Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var request = new GetOrderByIdRequest()
            {
                ID = id
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
        [Route("{ID}")]
        public Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var request = new DeleteOrderRequest()
            {
                ID = id
            };
            return this.HandleRequest<DeleteOrderRequest, DeleteOrderResponse>(request);
        }
    }
}
