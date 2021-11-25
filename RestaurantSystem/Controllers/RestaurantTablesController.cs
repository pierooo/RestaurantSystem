﻿using MediatR;
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
    public class RestaurantTablesController : ControllerBase
    {
        private readonly IMediator mediator;
        public RestaurantTablesController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllRestaurantTables([FromQuery] GetRestaurantTablesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{restaurantTableID}")]
        public async Task<IActionResult> GetRestaurantTableById([FromRoute] int restaurantTableID)
        {
            var request = new GetRestaurantTableByIdRequest
            {
                RestaurantTableID = restaurantTableID
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddRestaurantTable([FromBody] AddRestaurantTableRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutRestaurantTable([FromBody] PutRestaurantTableRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpDelete]
        [Route("{restaurantTableID}")]
        public async Task<IActionResult> DeleteRestaurantTable([FromRoute] int restaurantTableID)
        {
            var request = new DeleteRestaurantTableRequest()
            {
                RestaurantTableID = restaurantTableID
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
