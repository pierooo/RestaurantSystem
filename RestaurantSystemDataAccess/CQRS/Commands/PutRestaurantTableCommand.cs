using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class PutRestaurantTableCommand : CommandBase<RestaurantTable, RestaurantTable>
    {
        public async override Task<RestaurantTable> Execute(OrdersStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.RestaurantTables.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
