using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class AddRestaurantTableRequest : IRequest<AddRestaurantTableResponse>
    {
        public string Description { get; set; }
    }
}
