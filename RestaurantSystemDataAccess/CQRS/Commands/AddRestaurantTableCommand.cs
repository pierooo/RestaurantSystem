using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class AddRestaurantTableCommand : CommandBase<RestaurantTable, RestaurantTable>
    {
        public async override Task<RestaurantTable> Exetuce(OrdersStorageContext context)
        {
            await context.RestaurantTables.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
