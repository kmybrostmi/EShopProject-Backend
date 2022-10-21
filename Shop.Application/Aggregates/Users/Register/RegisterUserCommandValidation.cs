using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Aggregates.Users.Register;

public class RegisterUserCommandValidation:AbstractValidator<RegisterUserCommand>
{
	public RegisterUserCommandValidation()
	{
        RuleFor(f => f.Password)
            .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
            .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
            .MinimumLength(4).WithMessage("کلمه عبور باید بشتر از 4 کارکتر باشد");
    }
}

