using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public decimal UnitPriceNetto { get; set; }
        public int VAT { get; set; }

        public int Quantity { get; set; }
    }
}
