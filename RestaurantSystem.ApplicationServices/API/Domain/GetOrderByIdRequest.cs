using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class GetOrderByIdRequest : IRequest<GetOrderByIdResponse>
    {
        public int OrderID { get; set; }
    }
}
