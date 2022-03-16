using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.Entities
{
    public class Product : EntityBase
    {
        [MaxLength(250)]
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPriceNetto { get; set; }
        public int VAT { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }


    }
}
