using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Country)
                .NotEmpty().WithMessage("Country is required")
                .MinimumLength(4).WithMessage("Country name can't be less than 4 symbols");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("City is required")
                .MinimumLength(4).WithMessage("City name can't be less than 4 symbols")
                .MaximumLength(16).WithMessage("City name can't be more than 16 symbols");

            RuleFor(x => x.PostalCode)
                .Matches(@"^\d{5}(-\d{4})?$")
                .When(x => x.Country == "USA");

            RuleFor(x => x.PostalCode)
                .Matches(@"^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][ -]?\d[ABCEGHJ-NPRSTV-Z]\d$")
                .When(x => x.Country == "Canada");

            RuleFor(x => x.PostalCode)
                .Matches(@"^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})$")
                .When(x => x.Country == "UK");

            RuleFor(x => x.PostalCode)
                .Matches(@"^[A-Z0-9\s-]{3,10}$")
                .When(x => x.Country != "USA" && x.Country != "UK" && x.Country != "Canada");
        }
    }
}
