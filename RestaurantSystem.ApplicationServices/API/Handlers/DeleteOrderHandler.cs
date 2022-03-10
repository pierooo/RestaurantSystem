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
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteOrderHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteOrderResponse> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new DeleteOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
            else
            {
                var isOrderInDb = new GetOrderByIdQuery()
                {
                    OrderID = request.OrderID
                };
                var order = await queryExecutor.Execute(isOrderInDb);
                if (order == null)
                {
                    return null;
                }
                else
                {
                    var command = new DeleteOrderCommand()
                    {
                        Parameter = order
                    };
                    var responseFromDb = await this.commandExecutor.Execute(command);
                    var response = new DeleteOrderResponse();
                    if (responseFromDb == order)
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
