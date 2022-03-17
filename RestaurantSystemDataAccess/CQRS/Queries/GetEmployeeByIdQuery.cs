using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS.Queries;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class GetEmployeeByIdQuery : QueryBase<Employee>
    {
        public int ID { get; set; }
        public override async Task<Employee> Execute(OrdersStorageContext context)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.ID == this.ID);
            return employee;
        }
    }
}
