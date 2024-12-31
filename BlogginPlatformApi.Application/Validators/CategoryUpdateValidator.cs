using BloggingPlatformAPI.DTOs;
using FluentValidation;

namespace BloggingPlatformAPI.Validators
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("The category name is required")
                .Length(3, 50).WithMessage("The category name must be between 3 and 50 characters");
        }
    }
}
