using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int ID { get; set; }
    }
}
