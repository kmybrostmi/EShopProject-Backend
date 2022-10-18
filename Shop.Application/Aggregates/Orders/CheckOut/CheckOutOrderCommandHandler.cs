using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Aggregates.OrderAgg.Repository;
using Shop.Domain.OrderAgg;
using System.Security.AccessControl;

namespace Shop.Application.Aggregates.Orders.CheckOut;

public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOutOrderCommand>
{
    private readonly IOrderRepository _repository;

    public CheckOutOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
    {
        var currentOrder =  await _repository.GetCurrentUserOrder(request.UserId);
        if (currentOrder == null)
            return OperationResult.NotFound();

        var address = new OrderAddress(request.Shire, request.City, request.PostalCode,
                request.PostalAddress, request.PhoneNumber, request.Name,
                request.Family, request.NationalCode);

        currentOrder.Checkout(address);
        await _repository.Save();
        return OperationResult.Success();

    }
}


