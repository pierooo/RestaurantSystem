using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.Entities
{
    public class OrderDetails : EntityBase
    {
        public Order Order { get; set; }
        public int OrderID { get; set; }

        public Product Product { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPriceNetto { get; set; }
        public int VAT { get; set; }
        public int Quantity { get; set; }
    }
}
