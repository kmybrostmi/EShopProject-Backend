using Common.Application;
using Shop.Domain.Aggregates.OrderAgg.Repository;

namespace Shop.Application.Aggregates.Orders.IncreaseItemCount;

public class IncreaseOrderItemCountCommandHandler : IBaseCommandHandler<IncreaseOrderItemCountCommand>
{
    private readonly IOrderRepository _repository;

    public IncreaseOrderItemCountCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetCurrentUserOrder(request.UserId);
        if (order == null)
            return OperationResult.NotFound();

        order.IncreaseItemCount(request.ItemId, request.Count);
        await _repository.Save();
        return OperationResult.Success();
    }
}

