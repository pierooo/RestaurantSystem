using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class AddOrderCommand : CommandBase<Order, Order>
    {
        public async override Task<Order> Exetuce(OrdersStorageContext context)
        {
            await context.Orders.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
