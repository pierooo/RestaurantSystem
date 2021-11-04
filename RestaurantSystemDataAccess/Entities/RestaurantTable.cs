using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.Entities
{
    public class RestaurantTable : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public List<Order> Orders { get; set; }
    }
}
