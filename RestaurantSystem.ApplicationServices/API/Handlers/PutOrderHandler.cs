using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
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
    public class PutOrderHandler : IRequestHandler<PutOrderRequest, PutOrderResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutOrderResponse> Handle(PutOrderRequest request, CancellationToken cancellationToken)
        {
            var isOrderInDb = new GetOrderByIdQuery()
            {
                OrderID = request.OrderID
            };
            var orderID = await queryExecutor.Execute(isOrderInDb);
            if (orderID == null)
            {
                return null;
            }
            else
            {
                var orderMappedFromRequest = this.mapper.Map<Order>(request);
                var command = new PutOrderCommand()
                {
                    Parameter = orderMappedFromRequest
                };
                var orderFromDb = await this.commandExecutor.Execute(command);
                var mappedOrder = this.mapper.Map<Domain.Models.Order>(orderFromDb);
                var response = new PutOrderResponse()
                {
                    Data = mappedOrder
                };
                return response;
            }
        }
    }
}
