using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS;
using RestaurantSystemDataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, DeleteEmployeeResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteEmployeeHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteEmployeeResponse> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new DeleteEmployeeResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
            else
            {
                var isEmployeeInDb = new GetEmployeeByIdQuery()
                {
                    EmployeeID = request.EmployeeID
                };
                var employee = await queryExecutor.Execute(isEmployeeInDb);
                if (employee == null)
                {
                    return null;
                }
                else
                {
                    var command = new DeleteEmployeeCommand()
                    {
                        Parameter = employee
                    };
                    var responseFromDb = await this.commandExecutor.Execute(command);
                    var response = new DeleteEmployeeResponse();
                    if (responseFromDb == employee)
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
