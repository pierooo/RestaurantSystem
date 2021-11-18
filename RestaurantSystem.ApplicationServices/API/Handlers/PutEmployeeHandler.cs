using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS;
using RestaurantSystemDataAccess.CQRS.Commands;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Handlers
{
    public class PutEmployeeHandler : IRequestHandler<PutEmployeeRequest, PutEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;


        public PutEmployeeHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<PutEmployeeResponse> Handle(PutEmployeeRequest request, CancellationToken cancellationToken)
        {
            var isEmployeeInDb = new GetEmployeeByIdQuery()
            {
                EmployeeID = request.EmployeeID
            };
            var employeeID = await queryExecutor.Execute(isEmployeeInDb);
            if (employeeID == null)
            {
                return null;
            }
            else
            {
                var employeeMappedFromRequest = this.mapper.Map<Employee>(request);
                var command = new PutEmployeeCommand()
                {
                    Parameter = employeeMappedFromRequest
                };
                var employeeFromDb = await this.commandExecutor.Execute(command);
                var mappedEmployee = this.mapper.Map<Domain.Models.Employee>(employeeFromDb);
                var response = new PutEmployeeResponse()
                {
                    Data = mappedEmployee
                };
                return response;
            }

        }
    }
}
