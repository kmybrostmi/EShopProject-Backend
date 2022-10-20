using FluentValidation;

namespace Shop.Application.Aggregates.Orders.DecreaseItemCount;

public class DecreaseOrderItemCountCommandValidation:AbstractValidator<DecreaseOrderItemCountCommand>
{
    public DecreaseOrderItemCountCommandValidation()
    {
        RuleFor(f => f.Count)
                .LessThanOrEqualTo(0).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}

