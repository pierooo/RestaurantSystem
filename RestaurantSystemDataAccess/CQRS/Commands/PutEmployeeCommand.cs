using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class PutEmployeeCommand : CommandBase<Employee, Employee>
    {
        public async override Task<Employee> Execute(OrdersStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Employees.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
