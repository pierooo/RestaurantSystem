using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class DeleteRestaurantTableCommand : CommandBase<RestaurantTable, RestaurantTable>
    {
        public async override Task<RestaurantTable> Execute(OrdersStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.RestaurantTables.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
