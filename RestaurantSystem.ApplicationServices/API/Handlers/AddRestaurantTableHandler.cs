using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
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
    public class AddRestaurantTableHandler : IRequestHandler<AddRestaurantTableRequest, AddRestaurantTableResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddRestaurantTableHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddRestaurantTableResponse> Handle(AddRestaurantTableRequest request, CancellationToken cancellationToken)
        {
            var restaurantTable = this.mapper.Map<RestaurantTable>(request);
            var command = new AddRestaurantTableCommand() { Parameter = restaurantTable };
            var restaurantTableFromDb = await this.commandExecutor.Execute(command);
            return new AddRestaurantTableResponse()
            {
                Data = this.mapper.Map<Domain.Models.RestaurantTable>(restaurantTableFromDb)
            };
        }
    }
}
