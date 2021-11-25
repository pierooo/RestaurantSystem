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
    public class PutRestaurantTableHandler : IRequestHandler<PutRestaurantTableRequest, PutRestaurantTableResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutRestaurantTableHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutRestaurantTableResponse> Handle(PutRestaurantTableRequest request, CancellationToken cancellationToken)
        {
            var isRestaurantTableInDb = new GetRestaurantTableByIdQuery()
            {
                RestaurantTableID = request.RestaurantTableID
            };
            var restaurantTableID = await queryExecutor.Execute(isRestaurantTableInDb);
            if (restaurantTableID == null)
            {
                return null;
            }
            else
            {
                var restaurantTableMappedFromRequest = mapper.Map<RestaurantTable>(request);
                var command = new PutRestaurantTableCommand()
                {
                    Parameter = restaurantTableMappedFromRequest
                };
                var restaurantTableFromDb = await this.commandExecutor.Execute(command);
                var mappedRestaurantTable = this.mapper.Map<Domain.Models.RestaurantTable>(restaurantTableFromDb);
                var response = new PutRestaurantTableResponse()
                {
                    Data = mappedRestaurantTable
                };
                return response;
            }
        }
    }
}
