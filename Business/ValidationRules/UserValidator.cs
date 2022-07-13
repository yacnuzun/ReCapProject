using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2).NotEmpty();
            RuleFor(u => u.Email).MinimumLength(2).EmailAddress();
            //RuleFor(u => u.Password).MinimumLength(10).NotEmpty();


        }
    }
}
