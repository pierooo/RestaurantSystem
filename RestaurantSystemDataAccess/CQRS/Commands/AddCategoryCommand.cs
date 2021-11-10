using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Commands
{
    public class AddCategoryCommand : CommandBase<Category, Category>
    {

        public async override Task<Category> Exetuce(OrdersStorageContext context)
        {
            await context.Categories.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
