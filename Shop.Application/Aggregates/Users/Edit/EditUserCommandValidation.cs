using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Aggregates.Users.Edit;

public class EditUserCommandValidation:AbstractValidator<EditUserCommand>   
{
	public EditUserCommandValidation()
	{
        RuleFor(r => r.Email)
            .EmailAddress().WithMessage("ایمیل نامعتبر است");


        RuleFor(f => f.Avatar)
            .JustImageFile();
    }
}
