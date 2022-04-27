using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).MinimumLength(2).NotEmpty();
        }
    }
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.Id).NotEmpty();

            RuleFor(r => r.CarId).NotEmpty();

            RuleFor(r => r.RentDate).NotEmpty();
        }
    }
}
