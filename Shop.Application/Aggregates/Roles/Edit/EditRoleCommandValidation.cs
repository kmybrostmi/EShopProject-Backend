using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Aggregates.Roles.Edit;

public class EditRoleCommandValidation:AbstractValidator<EditRoleCommand>
{
	public EditRoleCommandValidation()
	{
        RuleFor(r => r.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}


