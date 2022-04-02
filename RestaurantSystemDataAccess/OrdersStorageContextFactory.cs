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
            //optionsBuilder.UseSqlServer(connectionString: "Server=tcp:restaurantsystem.database.windows.net,1433;Initial Catalog=RestaurantSystemStorage;Persist Security Info=False;User ID=piero;Password=RestaurantSystem123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            optionsBuilder.UseSqlServer(connectionString: "Data Source = PIOTR\\SQLEXPRESS; Initial Catalog = RestaurantSystemStorage; Integrated Security = True");
            return new OrdersStorageContext(optionsBuilder.Options);
        }
    }
}
