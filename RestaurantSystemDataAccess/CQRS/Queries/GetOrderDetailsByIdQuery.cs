using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetOrderDetailsByIdQuery : QueryBase<OrderDetails>
    {
        public int ID { get; set; }
        public override async Task<OrderDetails> Execute(OrdersStorageContext context)
        {
            var orderDetails = await context.OrdersDetails
                .Include(x => x.Order)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.ID == this.ID);
            return orderDetails;
        }
    }
}
