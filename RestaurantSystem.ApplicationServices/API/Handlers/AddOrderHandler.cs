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
    public class AddOrderHandler : IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddOrderHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            var order = this.mapper.Map<Order>(request);
            var command = new AddOrderCommand() { Parameter = order };
            var orderFromDb = await this.commandExecutor.Execute(command);
            return new AddOrderResponse()
            {
                Data = this.mapper.Map<Domain.Models.Order>(orderFromDb)
            };
        }
    }
}
