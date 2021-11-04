using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetOrderByIdQuery : QueryBase<Order>
    {
        public int OrderID { get; set; }
        public override async Task<Order> Execute(OrdersStorageContext context)
        {
            var order = await context.Orders
                .Include(x => x.Employee)
                .Include(x => x.RestaurantTable)
                .FirstOrDefaultAsync(x => x.ID == this.OrderID); 
                return order;
        }
    }
}
