using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Entities.SiteEntities.Banners.Edit;

public class EditBannerCommandValidation:AbstractValidator<EditBannerCommand>
{
	public EditBannerCommandValidation()
	{
        RuleFor(r => r.ImageFile)
            .JustImageFile();

        RuleFor(r => r.Link)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("لینک"));
    }
}

