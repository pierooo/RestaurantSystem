using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator, ILogger<ProductsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in ProductsController");
        }
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            return this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }
        [HttpGet]
        [Route("{ID}")]
        public Task<IActionResult> GetProductByID([FromRoute] int id)
        {
            var request = new GetProductByIdRequest()
            {
                ID = id
            };
            return this.HandleRequest<GetProductByIdRequest, GetProductByIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            return this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }
        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutProduct([FromBody] PutProductRequest request)
        {
            return this.HandleRequest<PutProductRequest, PutProductResponse>(request);
        }
        [HttpDelete]
        [Route("{ID}")]
        public Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var request = new DeleteProductRequest()
            {
                ID = id
            };
            return this.HandleRequest<DeleteProductRequest, DeleteProductResponse>(request);

        }
    }
}
