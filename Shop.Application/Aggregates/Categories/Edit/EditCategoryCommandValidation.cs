using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Aggregates.Categories.Edit;

public class EditCategoryCommandValidation:AbstractValidator<EditCategoryCommand>
{
    public EditCategoryCommandValidation()
    {
        RuleFor(r => r.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(r => r.Slug)
          .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
    }
}

