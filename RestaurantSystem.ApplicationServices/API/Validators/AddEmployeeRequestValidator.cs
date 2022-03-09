using FluentValidation;
using RestaurantSystem.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.API.Validators
{
    public class AddEmployeeRequestValidator : AbstractValidator<AddEmployeeRequest>
    {
        public AddEmployeeRequestValidator()
        {
            this.RuleFor(x => x.LastName).Length(1,250);
            this.RuleFor(x => x.FirstName).Length(1, 250);
        }
    }
}
