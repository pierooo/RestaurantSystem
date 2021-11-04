using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetRestaurantTablesQuery : QueryBase<List<RestaurantTable>>
    {
        public override Task<List<RestaurantTable>> Execute(OrdersStorageContext context)
        {
            return context.RestaurantTables.ToListAsync();
        }
    }
}
