﻿using Common.Application.Validation.FluentValidations;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Aggregates.Products.Edit;

public class EditProductCommandValidation:AbstractValidator<EditProductCommand> 
{
	public EditProductCommandValidation()
	{
        RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(r => r.Slug)
           .NotEmpty().WithMessage(ValidationMessages.required("Slug"));

        RuleFor(r => r.Description)
           .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

        RuleFor(r => r.ImageFile)
           .JustImageFile();
    }
}

