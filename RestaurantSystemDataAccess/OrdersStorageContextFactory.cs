using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace RestaurantSystemDataAccess
{
    public class OrdersStorageContextFactory : IDesignTimeDbContextFactory<OrdersStorageContext>
    {
        public OrdersStorageContext CreateDbContext([NotNull] string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrdersStorageContext>();
            optionsBuilder.UseSqlServer(connectionString: "Data Source = PIOTR\\SQLEXPRESS; Initial Catalog = RestaurantSystemStorage; Integrated Security = True");
            return new OrdersStorageContext(optionsBuilder.Options);
        }
    }
}
