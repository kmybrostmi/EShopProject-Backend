using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Aggregates.Products.AddImage;

public class AddProductImageCommandValidation:AbstractValidator<AddProductImageCommand>
{
	public AddProductImageCommandValidation()
	{

        RuleFor(b => b.ImageFile)
            .NotNull().WithMessage(ValidationMessages.required("عکس"))
            .JustImageFile();

        RuleFor(b => b.Sequence)
            .GreaterThanOrEqualTo(0);
    }
}

