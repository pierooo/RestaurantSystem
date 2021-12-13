using FluentValidation;
using RestaurantSystem.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Validators
{
    public class AddCategoryRequestValidator : AbstractValidator<AddCategoryRequest>
    {
        public AddCategoryRequestValidator()
        {
            this.RuleFor(x => x.CategoryName).NotNull();
            this.RuleFor(x => x.Description).MinimumLength(5).MaximumLength(500);
        }
    }
}
