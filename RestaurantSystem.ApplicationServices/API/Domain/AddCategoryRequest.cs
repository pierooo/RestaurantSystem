using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Domain
{
    public class AddCategoryRequest : IRequest<AddCategoryResponse>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
