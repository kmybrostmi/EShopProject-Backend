using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Aggregates.Comments.Create;

public class CreateCommentCommandValidation:AbstractValidator<CreateCommentCommand> 
{
    public CreateCommentCommandValidation()
    {
        RuleFor(r => r.Text)
                .NotNull()
                .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن نظر", 5));
    }
}


