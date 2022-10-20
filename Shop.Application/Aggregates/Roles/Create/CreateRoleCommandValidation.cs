using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Aggregates.Roles.Create;

public class CreateRoleCommandValidation:AbstractValidator<CreateRoleCommand>   
{
	public CreateRoleCommandValidation()
	{
        RuleFor(r => r.Title)
           .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}

