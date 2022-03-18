using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.Entities
{
    public class Order : EntityBase
    {
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        public RestaurantTable RestaurantTable { get; set; }
        public int RestaurantTableID { get; set; }

        public List<OrderDetails> OrdersDetails { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalPriceNetto { get; set; }
        public decimal TotalPriceBrutto { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public bool Completed { get; set; }

    }
}
