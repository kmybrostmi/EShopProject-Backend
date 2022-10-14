using Common.Application;
using Shop.Domain.Aggregates.OrderAgg.Repository;

namespace Shop.Application.Aggregates.Orders.CheckOut;

public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOutOrderCommand>
{
    private readonly IOrderRepository _repository;

    public CheckOutOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    public Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


