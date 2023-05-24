using FluentValidation;
using POS.Application.Dtos.Request;

namespace POS.Application.Validators.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotNull().WithMessage("The field can not be null")
                .NotEmpty().WithMessage("The field can not be empty");
            RuleFor(x => x.CategoryDescription)
                .NotNull().WithMessage("The field can not be null")
                .NotEmpty().WithMessage("The field can not be empty");

        }
    }
}
