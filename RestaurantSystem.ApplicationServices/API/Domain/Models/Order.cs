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
        public string Employee { get; set; }
        public string RestaurantTable { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
    }
}
