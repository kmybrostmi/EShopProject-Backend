using FluentValidation;

namespace Shop.Application.Aggregates.Orders.IncreaseItemCount;

public class IncreaseOrderItemCountCommandValidation:AbstractValidator<IncreaseOrderItemCountCommand>
{
    public IncreaseOrderItemCountCommandValidation()
    {
        RuleFor(f => f.Count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}

