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
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;
        public EmployeesController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployees([FromQuery] GetEmployeesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{employeeID}")]
        public async Task<IActionResult> GetEmployeeByID([FromRoute] int employeeID)
        {
            var request = new GetEmployeeByIdRequest()
            {
                EmployeeID = employeeID
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutEmployee([FromBody] PutEmployeeRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpDelete]
        [Route("{employeeID}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int employeeID)
        {
            var request = new DeleteEmployeeRequest()
            {
                EmployeeID = employeeID
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
