using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystemDataAccess;
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
    public class GetOrdersDetailsHandler : IRequestHandler<GetOrdersDetailsRequest, GetOrdersDetailsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;


        public GetOrdersDetailsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetOrdersDetailsResponse> Handle(GetOrdersDetailsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrdersDetailsQuery();
            var ordersDetails = await this.queryExecutor.Execute(query);
            var mappedOrderDetails = this.mapper.Map<List<Domain.Models.OrderDetails>>(ordersDetails);
            var response = new GetOrdersDetailsResponse()
            {
                Data = mappedOrderDetails
            };
            return response;

        }
    }
}
