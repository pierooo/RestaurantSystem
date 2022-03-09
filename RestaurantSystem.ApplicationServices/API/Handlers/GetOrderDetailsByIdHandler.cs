using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Handlers
{
    public class GetOrderDetailsByIdHandler : IRequestHandler<GetOrderDetailsByIdRequest, GetOrderDetailsByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrderDetailsByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetOrderDetailsByIdResponse> Handle(GetOrderDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailsByIdQuery()
            {
                OrderDetailsID = request.OrderDetailsID
            };
            var orderDetails = await this.queryExecutor.Execute(query);
            if (orderDetails == null)
            {
                return new GetOrderDetailsByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedOrderDetails = this.mapper.Map<Domain.Models.OrderDetails>(orderDetails);

            var response = new GetOrderDetailsByIdResponse()
            {
                Data = mappedOrderDetails
            };
            return response;
        }
    }
}
