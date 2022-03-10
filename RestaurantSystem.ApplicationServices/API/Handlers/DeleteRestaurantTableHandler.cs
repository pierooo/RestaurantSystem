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
    public class DeleteRestaurantTableHandler : IRequestHandler<DeleteRestaurantTableRequest, DeleteRestaurantTableResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteRestaurantTableHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteRestaurantTableResponse> Handle(DeleteRestaurantTableRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new DeleteRestaurantTableResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
            else
            {
                var isRestaurantTableInDb = new GetRestaurantTableByIdQuery()
                {
                    RestaurantTableID = request.RestaurantTableID
                };
                var restaurantTable = await queryExecutor.Execute(isRestaurantTableInDb);
                if (restaurantTable == null)
                {
                    return null;
                }
                else
                {
                    var command = new DeleteRestaurantTableCommand()
                    {
                        Parameter = restaurantTable
                    };
                    var responseFromDb = await this.commandExecutor.Execute(command);
                    var response = new DeleteRestaurantTableResponse();
                    if (responseFromDb == restaurantTable)
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
