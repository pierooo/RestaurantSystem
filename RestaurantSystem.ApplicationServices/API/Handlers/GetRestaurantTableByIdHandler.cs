using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
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
    public class GetRestaurantTableByIdHandler : IRequestHandler<GetRestaurantTableByIdRequest, GetRestaurantTableByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRestaurantTableByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetRestaurantTableByIdResponse> Handle(GetRestaurantTableByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRestaurantTableByIdQuery()
            {
                RestaurantTableID = request.RestaurantTableID
            };
            var restaurantTable = await this.queryExecutor.Execute(query);
            var mappedRestaurantTable = this.mapper.Map<Domain.Models.RestaurantTable>(restaurantTable);

            var response = new GetRestaurantTableByIdResponse()
            {
                Data = mappedRestaurantTable
            };
            return response;
        }
    }
}
