using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class AddProductRequest : RequestBase, IRequest<AddProductResponse>
    {
        public string ProductName { get; set; }
        public decimal UnitPriceNetto { get; set; }
        public int VAT { get; set; }
        public int CategoryID { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
