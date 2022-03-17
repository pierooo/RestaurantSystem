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
    public class CategoriesController : ApiControllerBase
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllCategories([FromQuery] GetCategoriesRequest request)
        {
            return this.HandleRequest<GetCategoriesRequest, GetCategoriesResponse>(request);
        }
        [HttpGet]
        [Route("{ID}")]
        public Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var request = new GetCategoryByIdRequest()
            {
                ID = id
            };
            return this.HandleRequest<GetCategoryByIdRequest, GetCategoryByIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
        {
            return this.HandleRequest<AddCategoryRequest, AddCategoryResponse>(request);
        }
        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutCategory([FromBody] PutCategoryRequest request)
        {
            return this.HandleRequest<PutCategoryRequest, PutCategoryResponse>(request);
        }
        [HttpDelete]
        [Route("{ID}")]
        public Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var request = new DeleteCategoryRequest()
            {
                ID = id
            };
            return this.HandleRequest<DeleteCategoryRequest, DeleteCategoryResponse>(request);
        }
    }
}
