using FluentValidation;

namespace Shop.Application.Aggregates.Orders.AddItem;

public class AddOrderCommandValidation : AbstractValidator<AddOrderCommand>
{
    public AddOrderCommandValidation()
    {
        RuleFor(f => f.Count)
           .LessThanOrEqualTo(0).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}



