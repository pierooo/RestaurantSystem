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
        [Route("{categoryID}")]
        public Task<IActionResult> GetCategoryById([FromRoute] int categoryID)
        {
            var request = new GetCategoryByIdRequest()
            {
                CategoryID = categoryID
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
        [Route("{categoryID}")]
        public Task<IActionResult> DeleteCategory([FromRoute] int categoryID)
        {
            var request = new DeleteCategoryRequest()
            {
                CategoryID = categoryID
            };
            return this.HandleRequest<DeleteCategoryRequest, DeleteCategoryResponse>(request);
        }
    }
}
