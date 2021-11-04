using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public override async Task<List<Product>> Execute(OrdersStorageContext context)
        {
            var products = await context.Products
                .Include(x => x.Category).ToListAsync();
            return products;
        }
    }
}
