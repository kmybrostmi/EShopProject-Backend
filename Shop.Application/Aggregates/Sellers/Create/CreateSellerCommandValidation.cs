using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Aggregates.Sellers.Create;

public class CreateSellerCommandValidation:AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidation()
    {
        RuleFor(r => r.ShopName)
           .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

        RuleFor(r => r.ShopName)
            .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
            .ValidNationalId();
    }
}

