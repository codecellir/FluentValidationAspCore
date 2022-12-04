using FluentValidation;

namespace MVCRazorValidation.Models
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Family)
                .NotEmpty();

            RuleFor(x => x.Age)
                .NotEmpty();
        }
    }
}
