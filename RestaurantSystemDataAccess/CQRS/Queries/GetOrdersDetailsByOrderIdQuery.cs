using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetOrdersDetailsByOrderIdQuery : QueryBase<List<OrderDetails>>
    {
        public int OrderID { get; set; }
        public override async Task<List<OrderDetails>> Execute(OrdersStorageContext context)
        {
            var ordersDetails = await context.OrdersDetails.Where(x => x.Order.ID == OrderID)
                .Include(x => x.Order)
                .Include(x=> x.Product)
                .ToListAsync();
            return ordersDetails;
        }
    }
}
