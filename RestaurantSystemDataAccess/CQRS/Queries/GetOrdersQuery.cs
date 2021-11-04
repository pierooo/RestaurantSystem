using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetOrdersQuery : QueryBase<List<Order>>
    {
        public override async Task<List<Order>> Execute(OrdersStorageContext context)
        {
            var orders = await context.Orders
                .Include(t => t.Employee)
                .Include(x => x.RestaurantTable).ToListAsync();
                
            return orders;
        }
    }
}
