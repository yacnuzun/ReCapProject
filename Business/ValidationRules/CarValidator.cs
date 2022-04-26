using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.CarName).MinimumLength(2).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0).NotEmpty();
        }
    }
}
