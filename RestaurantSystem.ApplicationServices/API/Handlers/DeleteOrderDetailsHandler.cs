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
    public class DeleteOrderDetailsHandler : IRequestHandler<DeleteOrderDetailsRequest, DeleteOrderDetailsResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteOrderDetailsHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteOrderDetailsResponse> Handle(DeleteOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new DeleteOrderDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
            else
            {
                var isOrderDetailsInDb = new GetOrderDetailsByIdQuery()
                {
                    OrderDetailsID = request.OrderDetailsID
                };
                var orderDetails = await queryExecutor.Execute(isOrderDetailsInDb);
                if (orderDetails == null)
                {
                    return null;
                }
                else
                {
                    var command = new DeleteOrderDetailsCommand()
                    {
                        Parameter = orderDetails
                    };
                    var responseFromDb = await this.commandExecutor.Execute(command);
                    var response = new DeleteOrderDetailsResponse();
                    if (responseFromDb == orderDetails)
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
