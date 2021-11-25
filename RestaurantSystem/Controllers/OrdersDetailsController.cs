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
    public class OrdersDetailsController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrdersDetailsController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrdersDetails([FromQuery] GetOrdersDetailsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("GetByOrderDetailsId/{orderDetailsID}")]
        public async Task<IActionResult> GetOrdersDetailsById([FromRoute] int orderDetailsID)
        {
            var request = new GetOrderDetailsByIdRequest()
            {
                OrderDetailsID = orderDetailsID
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("GetByOrderId/{orderID}")]
        public async Task<IActionResult> GetOrdersDetailsByOrderId([FromRoute] int orderID)
        {
            var request = new GetOrdersDetailsByOrderIdRequest()
            {
                OrderID = orderID
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddOrderDetails([FromBody] AddOrderDetailsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutOrderDetails([FromBody] PutOrderDetailsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpDelete]
        [Route("{orderDetailsID}")]
        public async Task<IActionResult> DeleteOrderDetails([FromRoute] int orderDetailsID)
        {
            var request = new DeleteOrderDetailsRequest()
            {
                OrderDetailsID = orderDetailsID
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
