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
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCategoryByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCategoryByIdQuery()
            {
                CategoryID = request.CategoryID
            };
            var category = await queryExecutor.Execute(query);
            if (category == null)
            {
                return new GetCategoryByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedCategory = this.mapper.Map<Domain.Models.Category>(category);

            var response = new GetCategoryByIdResponse()
            {
                Data = mappedCategory
            };
            return response;
        }
    }
}
