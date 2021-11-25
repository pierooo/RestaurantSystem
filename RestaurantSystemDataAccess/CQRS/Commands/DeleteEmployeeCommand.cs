using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class DeleteEmployeeCommand : CommandBase<Employee, Employee>
    {
        public async override Task<Employee> Execute(OrdersStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Employees.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
