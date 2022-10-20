using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Aggregates.Sellers.Edit;

public class EditSellerCommandValidation:AbstractValidator<EditSellerCommand>
{
	public EditSellerCommandValidation()
	{
        RuleFor(r => r.ShopName)
           .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

        RuleFor(r => r.ShopName)
            .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
            .ValidNationalId();
    }
}



