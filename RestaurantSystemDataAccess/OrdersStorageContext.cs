using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Entities;

namespace RestaurantSystemDataAccess
{
    public class OrdersStorageContext : DbContext
    {
        public OrdersStorageContext(DbContextOptions<OrdersStorageContext> opt) : base(opt)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<Order>  Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }

}
}
