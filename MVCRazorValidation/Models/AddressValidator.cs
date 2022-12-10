using FluentValidation;

namespace MVCRazorValidation.Models
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Continue;

            RuleFor(x => x.StreetName)
                .NotEmpty();

            RuleFor(x=>x.PostalCode) .NotEmpty();
        }
    }
}
