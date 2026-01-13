using Entities.Models;
using FluentValidation;

namespace Application.Validation
{
    public class AuthUserValidator : AbstractValidator<AuthUser>
    {
        public AuthUserValidator() 
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(user => user.Password)  
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
