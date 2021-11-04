using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetCategoryByIdQuery : QueryBase<Category>
    {
        public int CategoryID { get; set; }
        public override async Task<Category> Execute(OrdersStorageContext context)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.ID == this.CategoryID);
            return category;
        }
    }
}
