using Common.Application;
using Shop.Domain.Aggregates.OrderAgg.Repository;
using Shop.Domain.Aggregates.SellerAgg.Repository;
using Shop.Domain.OrderAgg;

namespace Shop.Application.Aggregates.Orders.AddItem;

public class AddOrderCommandHandler : IBaseCommandHandler<AddOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ISellerRepository _sellerRepository;

    public AddOrderCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
    {
        _orderRepository = orderRepository;
        _sellerRepository = sellerRepository;
    }
    public async Task<OperationResult> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
        if (inventory == null)
            return OperationResult.NotFound();

        if (inventory.Count < request.Count)
            return OperationResult.Error("تعداد محصولات درخواست شده بیشتر از موجودی است");


        var order = await _orderRepository.GetCurrentUserOrder(request.UserId);
        if (order == null)
        {
            order = new Order(request.UserId);
            order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
            _orderRepository.Add(order);
        }
        else
        {
            order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
        }

        if (ItemCountBiggerThanInventoryCount(inventory, order))
            return OperationResult.Error("تعداد محصولات درخواست شده بیشتر از موجودی است");

        await _orderRepository.Save();
        return OperationResult.Success();
    }

    private bool ItemCountBiggerThanInventoryCount(InventoryResult inventory, Order order)
    {
        var orderItem = order.Items.First(f => f.InventoryId == inventory.Id);
        if (orderItem.Count > inventory.Count)
            return true;

        return false;
    }
}



