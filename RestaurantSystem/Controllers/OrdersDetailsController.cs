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
    public class OrdersDetailsController : ApiControllerBase
    {
        public OrdersDetailsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllOrdersDetails([FromQuery] GetOrdersDetailsRequest request)
        {
            return this.HandleRequest<GetOrdersDetailsRequest, GetOrdersDetailsResponse>(request);
        }
        [HttpGet]
        [Route("GetByOrderDetailsId/{orderDetailsID}")]
        public Task<IActionResult> GetOrdersDetailsById([FromRoute] int orderDetailsID)
        {
            var request = new GetOrderDetailsByIdRequest()
            {
                OrderDetailsID = orderDetailsID
            };
            return this.HandleRequest<GetOrderDetailsByIdRequest, GetOrderDetailsByIdResponse>(request);
        }
        [HttpGet]
        [Route("GetByOrderId/{orderID}")]
        public Task<IActionResult> GetOrdersDetailsByOrderId([FromRoute] int orderID)
        {
            var request = new GetOrdersDetailsByOrderIdRequest()
            {
                OrderID = orderID
            };
            return this.HandleRequest<GetOrdersDetailsByOrderIdRequest, GetOrdersDetailsByOrderIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddOrderDetails([FromBody] AddOrderDetailsRequest request)
        {
            return this.HandleRequest<AddOrderDetailsRequest, AddOrderDetailsResponse>(request);
        }
        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutOrderDetails([FromBody] PutOrderDetailsRequest request)
        {
            return this.HandleRequest<PutOrderDetailsRequest, PutOrderDetailsResponse>(request);
        }
        [HttpDelete]
        [Route("{orderDetailsID}")]
        public Task<IActionResult> DeleteOrderDetails([FromRoute] int orderDetailsID)
        {
            var request = new DeleteOrderDetailsRequest()
            {
                OrderDetailsID = orderDetailsID
            };
            return this.HandleRequest<DeleteOrderDetailsRequest, DeleteOrderDetailsResponse>(request);
        }
    }
}
