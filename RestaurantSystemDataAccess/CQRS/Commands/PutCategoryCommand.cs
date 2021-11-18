using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class PutCategoryCommand : CommandBase<Category, Category>
    {
        public async override Task<Category> Execute(OrdersStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Categories.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
