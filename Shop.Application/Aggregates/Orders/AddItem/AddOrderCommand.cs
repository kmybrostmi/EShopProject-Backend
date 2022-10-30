using Common.Application;

namespace Shop.Application.Aggregates.Orders.AddItem;
public class AddOrderCommand : IBaseCommand<Guid>
{
    public AddOrderCommand(Guid inventoryId, Guid userId, int count)
    {
        InventoryId = inventoryId;
        UserId = userId;
        Count = count;
    }

    public Guid InventoryId { get; private set; }
    public Guid UserId { get; private set; }
    public int Count { get; private set; }
}



