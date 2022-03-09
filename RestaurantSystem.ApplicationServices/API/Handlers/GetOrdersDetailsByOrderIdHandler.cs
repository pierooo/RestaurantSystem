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
    public class GetOrdersDetailsByOrderIdHandler : IRequestHandler<GetOrdersDetailsByOrderIdRequest, GetOrdersDetailsByOrderIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrdersDetailsByOrderIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrdersDetailsByOrderIdResponse> Handle(GetOrdersDetailsByOrderIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrdersDetailsByOrderIdQuery()
            {
                OrderID = request.OrderID
            };
            var ordersDetails = await this.queryExecutor.Execute(query);
            if (ordersDetails == null)
            {
                return new GetOrdersDetailsByOrderIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedOrdersDetails = this.mapper.Map<List<Domain.Models.OrderDetails>>(ordersDetails);

            var response = new GetOrdersDetailsByOrderIdResponse()
            {
                Data = mappedOrdersDetails
            };
            return response;
        }
    }
}
