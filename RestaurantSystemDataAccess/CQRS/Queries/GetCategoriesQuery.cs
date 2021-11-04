using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetCategoriesQuery : QueryBase<List<Category>>
    {
        public override Task<List<Category>> Execute(OrdersStorageContext context)
        {
            return context.Categories.ToListAsync();
        }
    }
}
