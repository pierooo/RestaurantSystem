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
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetCategoriesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{categoryID}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int categoryID)
        {
            var request = new GetCategoryByIdRequest()
            {
                CategoryID = categoryID
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
