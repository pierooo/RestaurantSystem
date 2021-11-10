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
    public class AddOrderDetailsHandler : IRequestHandler<AddOrderDetailsRequest, AddOrderDetailsResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddOrderDetailsHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddOrderDetailsResponse> Handle(AddOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var orderDetails = this.mapper.Map<OrderDetails>(request);
            var command = new AddOrderDetailsCommad() { Parameter = orderDetails };
            var orderDetailsFromDb = await this.commandExecutor.Execute(command);
            return new AddOrderDetailsResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDetails>(orderDetailsFromDb)
            };
        }
    }
}
