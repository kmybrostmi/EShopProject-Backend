using Common.Application;
using Shop.Domain.Aggregates.OrderAgg.Repository;

namespace Shop.Application.Aggregates.Orders.RemoveItem;

public class RemoveOrderItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
{
    private readonly IOrderRepository _repository;

    public RemoveOrderItemCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetCurrentUserOrder(request.UserId);
        if (order == null)
            return OperationResult.NotFound();

        order.RemoveItem(request.OrderItermId);
        await _repository.Save();
        return OperationResult.Success();   
    }
}

