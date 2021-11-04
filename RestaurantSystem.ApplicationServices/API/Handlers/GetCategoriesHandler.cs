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
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCategoriesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCategoriesQuery();
            var categories = await this.queryExecutor.Execute(query);
            var mappedCategories = this.mapper.Map<List<Domain.Models.Category>>(categories);
            var response = new GetCategoriesResponse()
            {
                Data = mappedCategories
            };
            return response;
        }
    }
}
