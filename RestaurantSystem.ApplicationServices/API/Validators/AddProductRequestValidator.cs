using FluentValidation;
using RestaurantSystem.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Validators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            this.RuleFor(x => x.UnitPriceNetto).InclusiveBetween(0,5000);
            this.RuleFor(x => x.ProductName).Length(1,200);
            this.RuleFor(x => x.CategoryID).InclusiveBetween(0,500);
        }
    }
}
