using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class DeleteOrderRequest : IRequest<DeleteOrderResponse>
    {
        public int OrderID { get; set; }
    }
}
