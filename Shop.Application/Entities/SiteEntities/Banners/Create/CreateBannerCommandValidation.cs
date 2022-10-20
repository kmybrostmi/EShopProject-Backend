using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Entities.SiteEntities.Banners.Create;

public class CreateBannerCommandValidation:AbstractValidator<CreateBannerCommand>   
{
	public CreateBannerCommandValidation()
	{
        RuleFor(r => r.ImageFile)
            .NotNull().WithMessage(ValidationMessages.required("عکس"))
            .JustImageFile();

        RuleFor(r => r.Link)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("لینک"));
    }
}

