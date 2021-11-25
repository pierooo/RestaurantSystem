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
    public class PutOrderDetailsHandler : IRequestHandler<PutOrderDetailsRequest, PutOrderDetailsResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutOrderDetailsHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutOrderDetailsResponse> Handle(PutOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var isOrderDetailsInDb = new GetOrderDetailsByIdQuery()
            {
                OrderDetailsID = request.OrderDetailsID
            };
            var orderDetailsID = await queryExecutor.Execute(isOrderDetailsInDb);
            if (orderDetailsID == null)
            {
                return null;
            }
            else
            {
                var orderDetailsMappedFromRequest = this.mapper.Map<OrderDetails>(request);
                var command = new PutOrderDetailsCommand()
                {
                    Parameter = orderDetailsMappedFromRequest
                };
                var orderDetailsFromDb = await this.commandExecutor.Execute(command);
                var mappedOrderDetails = this.mapper.Map<Domain.Models.OrderDetails>(orderDetailsFromDb);
                var response = new PutOrderDetailsResponse()
                {
                    Data = mappedOrderDetails
                };
                return response;
            }
        }
    }
}
