using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
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
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetEmployeesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new GetEmployeesResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
            else
            {
                var query = new GetEmployeesQuery();
                var employees = await this.queryExecutor.Execute(query);
                var mappedEmployees = this.mapper.Map<List<Domain.Models.Employee>>(employees);
                var response = new GetEmployeesResponse()
                {
                    Data = mappedEmployees
                };
                return response;
            }
        }
    }
}

