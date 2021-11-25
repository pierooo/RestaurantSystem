using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class PutOrderDetailsCommand : CommandBase<OrderDetails, OrderDetails>
    {
        public async override Task<OrderDetails> Execute(OrdersStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.OrdersDetails.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
