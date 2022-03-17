using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public class GetProductByIdQuery : QueryBase<Product>
    {
        public int ID { get; set; }
        public override async Task<Product> Execute(OrdersStorageContext context)
        {
            var product = await context.Products.Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.ID == this.ID);
            return product;
        }
    }
}
