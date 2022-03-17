using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetRestaurantTableByIdQuery : QueryBase<RestaurantTable>
    {
        public int ID { get; set; }

        public async override Task<RestaurantTable> Execute(OrdersStorageContext context)
        {
            var restaurantTable = await context.RestaurantTables
                .FirstOrDefaultAsync(x => x.ID == this.ID);
            return restaurantTable;
        }
    }
}
