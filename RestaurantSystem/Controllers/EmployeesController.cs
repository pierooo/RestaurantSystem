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
    public class EmployeesController : ApiControllerBase
    {
        public EmployeesController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllEmployees([FromQuery] GetEmployeesRequest request)
        {
            return HandleRequest<GetEmployeesRequest, GetEmployeesResponse>(request);
        }
        
        [HttpGet]
        [Route("{ID}")]
        public Task<IActionResult> GetEmployeeByID([FromRoute] int id)
        {
            var request = new GetEmployeeByIdRequest()
            {
                ID = id
            };
            return this.HandleRequest<GetEmployeeByIdRequest, GetEmployeeByIdResponse>(request);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            return this.HandleRequest<AddEmployeeRequest, AddEmployeeResponse>(request);
        }
        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutEmployee([FromBody] PutEmployeeRequest request)
        {
            return this.HandleRequest<PutEmployeeRequest, PutEmployeeResponse>(request);
        }
        [HttpDelete]
        [Route("{ID}")]
        public Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var request = new DeleteEmployeeRequest()
            {
                ID = id
            };
            return this.HandleRequest<DeleteEmployeeRequest, DeleteEmployeeResponse>(request);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public Task<IActionResult> Post([FromBody] ValidateEmployeeRequest request)
        {
            return this.HandleRequest<ValidateEmployeeRequest, ValidateEmployeeResponse>(request);
        }


    }
}
