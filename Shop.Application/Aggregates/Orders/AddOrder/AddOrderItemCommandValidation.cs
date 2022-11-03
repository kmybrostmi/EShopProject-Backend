using FluentValidation;

namespace Shop.Application.Aggregates.Orders.AddItem;

public class AddOrderItemCommandValidation : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemCommandValidation()
    {
        RuleFor(f => f.Count)
           .LessThanOrEqualTo(0).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}



