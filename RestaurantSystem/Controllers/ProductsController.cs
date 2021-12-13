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
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            return this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }
        [HttpGet]
        [Route("{productID}")]
        public Task<IActionResult> GetProductByID([FromRoute] int productID)
        {
            var request = new GetProductByIdRequest()
            {
                ProductID = productID
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
        [Route("{productID}")]
        public Task<IActionResult> DeleteProduct([FromRoute] int productID)
        {
            var request = new DeleteProductRequest()
            {
                ProductID = productID
            };
            return this.HandleRequest<DeleteProductRequest, DeleteProductResponse>(request);

        }
    }
}
