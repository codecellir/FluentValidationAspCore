using FluentValidation;

namespace MVCRazorValidation.Models
{
    public class CourseValidator:AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Continue;

            RuleFor(x => x.CourseName)
                .NotEmpty();

            RuleFor(x => x.Score)
                .InclusiveBetween(0, 20);
        }
    }
}
