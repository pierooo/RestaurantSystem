using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class DeleteProductCommand : CommandBase<Product, Product>
    {
        public async override Task<Product> Execute(OrdersStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Products.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
