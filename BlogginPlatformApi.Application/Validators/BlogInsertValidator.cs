using BloggingPlatformAPI.DTOs;
using FluentValidation;

namespace BloggingPlatformAPI.Validators
{
    public class BlogInsertValidator : AbstractValidator<BlogInsertDTO>
    {
        public BlogInsertValidator()
        {
            RuleFor(blog => blog.Title)
                .NotEmpty().WithMessage("The blog title is required")
                .Length(5, 100).WithMessage("The title must be between 5 and 100 characters");

            RuleFor(blog => blog.Content)
                .NotEmpty().WithMessage("The blog content is required")
                .MinimumLength(50).WithMessage("The content must be at least 50 characters long");

            RuleFor(blog => blog.CategoryId)
                .GreaterThan(0).WithMessage("A valid category ID is required");

            RuleFor(blog => blog.Tags)
                .Must(tags => tags == null || tags.All(tag => tag.Length <= 20))
                .WithMessage("Tags must not exceed 20 characters");
        }
    }
}
