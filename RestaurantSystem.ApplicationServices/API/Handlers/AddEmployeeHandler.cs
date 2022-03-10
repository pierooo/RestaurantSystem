using AutoMapper;
using MediatR;
using RestaurantSystem.ApplicationServices.API.Domain;
using RestaurantSystem.ApplicationServices.Components.PasswordHash;
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
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IPasswordHash passwordHash;
        public AddEmployeeHandler(ICommandExecutor commandExecutor, IMapper mapper, IPasswordHash passwordHash)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.passwordHash = passwordHash;
        }
        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = this.mapper.Map<Employee>(request);
            var hashedPasswordAndSalt = passwordHash.Hash(employee.Password);
            employee.Salt = hashedPasswordAndSalt[0];
            employee.Password = hashedPasswordAndSalt[1];
            var command = new AddEmployeeCommand() { Parameter = employee };
            var employeeFromDb = await this.commandExecutor.Execute(command);
            return new AddEmployeeResponse()
            {
                Data = this.mapper.Map<Domain.Models.Employee>(employeeFromDb)
            };
        }
    }
}
