using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.API.ErrorHandling;
using RestaurantSystem.ApplicationServices.Components.PasswordHash;
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
    public class ValidateEmployeeHandler : IRequestHandler<ValidateEmployeeRequest, ValidateEmployeeResponse>
    {
        private readonly IMediator mediator;
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHash passwordHash;
        private readonly IMapper mapper;
        public ValidateEmployeeHandler(IMediator mediator, IQueryExecutor queryExecutor, IPasswordHash passwordHash, IMapper mapper)
        {
            this.mediator = mediator;
            this.queryExecutor = queryExecutor;
            this.passwordHash = passwordHash;
            this.mapper = mapper;
        }
        public async Task<ValidateEmployeeResponse> Handle(ValidateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeByUsernameQuery()
            {
                Username = request.Username
            };
            var employee = await this.queryExecutor.Execute(query);
            if (employee != null)
            {
                var password = passwordHash.HashToCheck(request.Password, employee.Salt);
                if (employee.Password == password)
                {
                    var mappedEmployee = this.mapper.Map<Domain.Models.Employee>(employee);
                    return new ValidateEmployeeResponse()
                    {
                        Data = mappedEmployee
                    };
                }
                else
                {
                    return new ValidateEmployeeResponse()
                    {
                        Error = new ErrorModel(ErrorType.Unautorized)
                    };
                }
            }
            else
            {
                return new ValidateEmployeeResponse()
                {
                    Error = new ErrorModel(ErrorType.Unautorized)
                };
            }
        }
    }
}
