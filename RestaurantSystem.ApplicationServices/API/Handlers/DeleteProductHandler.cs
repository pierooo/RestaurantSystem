using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS;
using RestaurantSystemDataAccess.CQRS.Commands;
using RestaurantSystemDataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteProductHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new DeleteProductResponse()
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
                var product = await queryExecutor.Execute(isProductInDb);
                if (product == null)
                {
                    return null;
                }
                else
                {
                    var command = new DeleteProductCommand()
                    {
                        Parameter = product
                    };
                    var responseFromDb = await this.commandExecutor.Execute(command);
                    var response = new DeleteProductResponse();
                    if (responseFromDb == product)
                    {
                        response.Data = true;
                    }
                    else
                    {
                        response.Data = false;
                    }
                    return response;
                }
            }
        }
    }
}
