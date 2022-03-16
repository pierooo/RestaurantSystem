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
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddProductHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor= commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new AddProductResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
            else
            {
                var query = new GetCategoryByIdQuery()
                {
                    CategoryID = request.CategoryID
                };
                var category = this.queryExecutor.Execute(query);
                if(category != null)
                {
                    var product = this.mapper.Map<Product>(request);
                    var command = new AddProductCommand() { Parameter = product };
                    var productFromDb = await this.commandExecutor.Execute(command);
                    return new AddProductResponse()
                    {
                        Data = this.mapper.Map<Domain.Models.Product>(productFromDb)
                    };
                }
                else
                {
                    return new AddProductResponse()
                    {
                        Error = new ErrorModel(ErrorType.ValidationError)
                    };
                }
                
            }
        }
    }
}
