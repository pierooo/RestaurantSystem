using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class PutRestaurantTableRequest : RequestBase, IRequest<PutRestaurantTableResponse>
    {
        public int RestaurantTableID { get; set; }
        public string Description { get; set; }
    }
}
