using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS;
using RestaurantSystemDataAccess.CQRS.Commands;
using RestaurantSystemDataAccess.CQRS.Queries;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Handlers
{
    public class PutProductHandler : IRequestHandler<PutProductRequest, PutProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor; 
        private readonly IQueryExecutor queryExecutor;


        public PutProductHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutProductResponse> Handle(PutProductRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new PutProductResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
            else
            {
                var isProductInDb = new GetProductByIdQuery()
                {
                    ProductID = request.ProductID
                };
                var productID = await queryExecutor.Execute(isProductInDb);
                if (productID == null)
                {
                    return null;
                }
                else
                {
                    var productMappedFromRequest = this.mapper.Map<Product>(request);
                    var command = new PutProductCommand()
                    {
                        Parameter = productMappedFromRequest
                    };
                    var productFromDb = await this.commandExecutor.Execute(command);
                    var mappedProduct = this.mapper.Map<Domain.Models.Product>(productFromDb);
                    var response = new PutProductResponse()
                    {
                        Data = mappedProduct
                    };
                    return response;
                }
            }
        }
    }
}
