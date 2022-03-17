using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class PutProductRequest : RequestBase, IRequest<PutProductResponse>
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPriceNetto { get; set; }
        public int VAT { get; set; }
        public int CategoryID { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
