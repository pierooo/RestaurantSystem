using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class DeleteOrderCommand : CommandBase<Order, Order>
    {
        public async override Task<Order> Execute(OrdersStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Orders.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
