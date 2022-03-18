using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int RestaurantTableID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPriceNetto { get; set; }
        public decimal TotalPriceBrutto { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
