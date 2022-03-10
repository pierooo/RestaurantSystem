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
    public class PutCategoryHandler : IRequestHandler<PutCategoryRequest, PutCategoryResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        public PutCategoryHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutCategoryResponse> Handle(PutCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new PutCategoryResponse()
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
                var categoryID = await queryExecutor.Execute(isCategoryInDb);
                if (categoryID == null)
                {
                    return null;
                }
                else
                {
                    var categoryMappedFromRequest = this.mapper.Map<Category>(request);
                    var command = new PutCategoryCommand()
                    {
                        Parameter = categoryMappedFromRequest
                    };
                    var categoryFromDb = await commandExecutor.Execute(command);
                    var mappedCategory = this.mapper.Map<Domain.Models.Category>(categoryFromDb);
                    var response = new PutCategoryResponse()
                    {
                        Data = mappedCategory
                    };
                    return response;
                }
            }
        }
    }
}
