using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetOrdersDetailsQuery : QueryBase<List<OrderDetails>>
    {
        public override async Task<List<OrderDetails>> Execute(OrdersStorageContext context)
        {
            var ordersdetails = await context.OrdersDetails
                .Include(x => x.Order)
                .Include(x => x.Product).ToListAsync();
            return ordersdetails;
        }
    }
}
