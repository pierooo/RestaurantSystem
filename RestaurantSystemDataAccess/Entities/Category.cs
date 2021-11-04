using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.Entities
{
    public class Category : EntityBase
    {
        [MaxLength(100)]
        public string CategoryName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
