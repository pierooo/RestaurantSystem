using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetEmployeeByUsernameQuery:QueryBase<Employee>
    {
        public string Username { get; set; }
        public override async Task<Employee> Execute(OrdersStorageContext context)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Username == this.Username);
            return employee;
        }
    }
}
