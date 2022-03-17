using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
using RestaurantSystem.Controllers;
using RestaurantSystemDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetEmployeeByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole.ToString() == "Waiter")
            {
                return new GetEmployeeByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
            else
            {
                var query = new GetEmployeeByIdQuery()
                {
                    ID = request.ID
                };
                var employee = await queryExecutor.Execute(query);
                if (employee == null)
                {
                    return new GetEmployeeByIdResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                var mappedOrder = this.mapper.Map<Domain.Models.Employee>(employee);

                var response = new GetEmployeeByIdResponse()
                {
                    Data = mappedOrder
                };
                return response;
            }
        }
    }
}
