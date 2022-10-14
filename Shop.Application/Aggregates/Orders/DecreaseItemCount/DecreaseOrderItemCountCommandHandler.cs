using Common.Application;
using Shop.Domain.Aggregates.OrderAgg.Repository;

namespace Shop.Application.Aggregates.Orders.DecreaseItemCount;

public class DecreaseOrderItemCountCommandHandler : IBaseCommandHandler<DecreaseOrderItemCountCommand>
{
    private readonly IOrderRepository _repository;

    public DecreaseOrderItemCountCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(DecreaseOrderItemCountCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetCurrentUserOrder(request.UserId);
        if (order == null)
            return OperationResult.NotFound();

        order.DecreaseItemCount(request.ItemId, request.Count);
        await _repository.Save();
        return OperationResult.Success();
    }
}
