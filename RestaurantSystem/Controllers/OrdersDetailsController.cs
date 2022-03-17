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
        [Route("GetByOrderDetailsId/{ID}")]
        public Task<IActionResult> GetOrdersDetailsById([FromRoute] int id)
        {
            var request = new GetOrderDetailsByIdRequest()
            {
                ID = id
            };
            return this.HandleRequest<GetOrderDetailsByIdRequest, GetOrderDetailsByIdResponse>(request);
        }
        [HttpGet]
        [Route("GetByOrderId/{ID}")]
        public Task<IActionResult> GetOrdersDetailsByOrderId([FromRoute] int id)
        {
            var request = new GetOrdersDetailsByOrderIdRequest()
            {
                ID = id
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
        [Route("{ID}")]
        public Task<IActionResult> DeleteOrderDetails([FromRoute] int id)
        {
            var request = new DeleteOrderDetailsRequest()
            {
                ID = id
            };
            return this.HandleRequest<DeleteOrderDetailsRequest, DeleteOrderDetailsResponse>(request);
        }
    }
}
