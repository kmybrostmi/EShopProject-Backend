using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Aggregates.Comments.Edit;

public class EditCommentCommandValidation:AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidation()
    {
        RuleFor(r => r.Text)
                .NotNull()
                .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن نظر", 5));
    }
}


