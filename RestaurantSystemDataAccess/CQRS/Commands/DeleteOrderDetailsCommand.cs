using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class DeleteOrderDetailsCommand : CommandBase<OrderDetails, OrderDetails>
    {
        public async override Task<OrderDetails> Execute(OrdersStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.OrdersDetails.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
