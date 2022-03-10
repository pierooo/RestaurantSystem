using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.Entities
{
    public class Employee : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public string Salt { get; set; }
        public List<Order> Orders { get; set; }

    }
}
