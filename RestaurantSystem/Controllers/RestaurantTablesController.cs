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
    public class RestaurantTablesController : ApiControllerBase
    {
        public RestaurantTablesController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllRestaurantTables([FromQuery] GetRestaurantTablesRequest request)
        {
            return this.HandleRequest<GetRestaurantTablesRequest, GetRestaurantTablesResponse>(request);
        }
        [HttpGet]
        [Route("{restaurantTableID}")]
        public Task<IActionResult> GetRestaurantTableById([FromRoute] int restaurantTableID)
        {
            var request = new GetRestaurantTableByIdRequest
            {
                RestaurantTableID = restaurantTableID
            };
            return this.HandleRequest<GetRestaurantTableByIdRequest, GetRestaurantTableByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddRestaurantTable([FromBody] AddRestaurantTableRequest request)
        {
            return this.HandleRequest<AddRestaurantTableRequest, AddRestaurantTableResponse>(request);
        }
        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutRestaurantTable([FromBody] PutRestaurantTableRequest request)
        {
            return this.HandleRequest<PutRestaurantTableRequest, PutRestaurantTableResponse>(request);
        }
        [HttpDelete]
        [Route("{restaurantTableID}")]
        public Task<IActionResult> DeleteRestaurantTable([FromRoute] int restaurantTableID)
        {
            var request = new DeleteRestaurantTableRequest()
            {
                RestaurantTableID = restaurantTableID
            };
            return this.HandleRequest<DeleteRestaurantTableRequest, DeleteRestaurantTableResponse>(request);
        }
    }
}
