﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class PutOrderDetailsRequest : RequestBase, IRequest<PutOrderDetailsResponse>
    {
        public int ID { get; set; }
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }
    }
}
