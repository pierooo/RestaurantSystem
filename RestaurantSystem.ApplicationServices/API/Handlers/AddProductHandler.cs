using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS;
using RestaurantSystemDataAccess.CQRS.Commands;
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

        public AddProductHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor= commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<Product>(request);
            var command = new AddProductCommand() { Parameter = product};
            var productFromDb =  await this.commandExecutor.Execute(command);
            return new AddProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.Product>(productFromDb)
            };
        }
    }
}
