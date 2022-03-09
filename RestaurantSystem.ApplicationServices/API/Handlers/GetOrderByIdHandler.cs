using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.Domain.Models;
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
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrderByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderByIdQuery()
            {
                OrderID = request.OrderID
            };
            var order = await this.queryExecutor.Execute(query);
            if (order == null)
            {
                return new GetOrderByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedOrder = this.mapper.Map<Domain.Models.Order>(order);

            var response = new GetOrderByIdResponse()
            {
                Data = mappedOrder
            };
            return response;
        }
    }
}
