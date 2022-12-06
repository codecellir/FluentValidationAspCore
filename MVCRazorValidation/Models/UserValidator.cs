using FluentValidation;

namespace MVCRazorValidation.Models
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Continue;

            RuleFor(x => x.Name)
                //.NotEmpty()
                //.MinimumLength(5);
                //.MaximumLength(10);
                .Length(5, 10);

            RuleFor(x => x.Family)
                //.NotNull();
                .Null();

            RuleFor(x => x.Age)
               //.NotEmpty();
               //.NotNull();
               //.LessThan(5);
               //.LessThanOrEqualTo(5);
               // .GreaterThan(5);
               //.GreaterThanOrEqualTo(5);
               //.InclusiveBetween(5, 10);
               .ExclusiveBetween(5, 10);

            RuleFor(x => x.Email)
                .EmailAddress();

            //Regular Expression Validator
            RuleFor(x => x.Mobile)
            .Matches(@"^09\d{9}$");

            //Predicate Validator example
            RuleFor(x => x.ShabaNumber)
                .Must(x => x.StartsWith("IR", StringComparison.OrdinalIgnoreCase))
                .Length(36);
        }
    }
}
