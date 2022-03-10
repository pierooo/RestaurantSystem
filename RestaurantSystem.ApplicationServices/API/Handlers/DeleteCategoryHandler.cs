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
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteCategoryHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new DeleteCategoryResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
            else
            {
                var isCategoryInDb = new GetCategoryByIdQuery()
                {
                    CategoryID = request.CategoryID
                };
                var category = await queryExecutor.Execute(isCategoryInDb);
                if (category == null)
                {
                    return null;
                }
                else
                {
                    var command = new DeleteCategoryCommand()
                    {
                        Parameter = category
                    };
                    var responseFromDb = await this.commandExecutor.Execute(command);
                    var response = new DeleteCategoryResponse();
                    if (responseFromDb == category)
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
