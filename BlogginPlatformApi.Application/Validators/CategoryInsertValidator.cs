using BloggingPlatformAPI.DTOs;
using FluentValidation;

namespace BloggingPlatformAPI.Validators
{
    public class CategoryInsertValidator : AbstractValidator<CategoryInsertDTO>
    {
        public CategoryInsertValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(3, 50).WithMessage("{PropertyName} name must be between 3 and 50 characters");
        }
    }
}
