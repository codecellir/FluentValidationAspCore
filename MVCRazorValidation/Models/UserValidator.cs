using FluentValidation;

namespace MVCRazorValidation.Models
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Continue;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithName("first name")
                .WithMessage("enter your {PropertyName}")
            .MinimumLength(5)
            .WithMessage("{PropertyName} must greater than or equal {MinLength} charachter, you are entered {TotalLength} charachter")
            .MaximumLength(10)
            .WithMessage("{PropertyName} must less than or equal {MaxLength} charachter, you are entered {TotalLength} charachter")
            .NotEqual("codecell")
            .WithMessage("{ComparisonValue} is not valid for {PropertyName}")
            .NotEqual(x => x.Mobile)
            .WithMessage("{ComparisonProperty} and {PropertyName} can not equal");
            //.Length(5, 10);

            RuleFor(x => x.Family).NotEmpty();
                //.NotNull();
                //.Null();

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
                .NotEmpty();
            //.EmailAddress();

            //Regular Expression Validator
            RuleFor(x => x.Mobile).NotEmpty();
            //.Matches(@"^09\d{9}$");

            //Predicate Validator example
            RuleFor(x => x.ShabaNumber).NotEmpty();
            //.Must(x => x.StartsWith("IR", StringComparison.OrdinalIgnoreCase))
            //.Length(36);

            RuleFor(x => x.Address)
                .SetValidator(new AddressValidator());

            RuleForEach(x=>x.Courses)
                .SetValidator(new CourseValidator());
        }
    }
}
