using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class PutOrderRequest : RequestBase, IRequest<PutOrderResponse>
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int RestaurantTableID { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
