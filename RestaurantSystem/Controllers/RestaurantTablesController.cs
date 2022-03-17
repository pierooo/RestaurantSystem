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
        [Route("{ID}")]
        public Task<IActionResult> GetRestaurantTableById([FromRoute] int id)
        {
            var request = new GetRestaurantTableByIdRequest
            {
                ID = id
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
        [Route("{ID}")]
        public Task<IActionResult> DeleteRestaurantTable([FromRoute] int id)
        {
            var request = new DeleteRestaurantTableRequest()
            {
                ID = id
            };
            return this.HandleRequest<DeleteRestaurantTableRequest, DeleteRestaurantTableResponse>(request);
        }
    }
}
