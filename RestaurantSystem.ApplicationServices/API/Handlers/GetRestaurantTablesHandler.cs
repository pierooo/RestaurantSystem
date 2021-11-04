using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.Entities;
using RestaurantSystemDataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Handlers
{
    public class GetRestaurantTablesHandler : IRequestHandler<GetRestaurantTablesRequest, GetRestaurantTablesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRestaurantTablesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetRestaurantTablesResponse> Handle(GetRestaurantTablesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRestaurantTablesQuery();
            var restaurantTables = await this.queryExecutor.Execute(query);
            var mappedRestaurantTables = this.mapper.Map<List<Domain.Models.RestaurantTable>>(restaurantTables);
            var response = new GetRestaurantTablesResponse()
            {
                Data = mappedRestaurantTables
            };
            return response;
        }
    }
}
