using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).MinimumLength(5).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();

        }
    }
}
