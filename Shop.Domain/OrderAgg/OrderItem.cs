namespace Shop.Domain.OrderAgg;

public class OrderItem
{
    public OrderItem(Guid inventoryId, int count, int price)
    {
        InventoryId = inventoryId;
        Count = count;
        Price = price;
    }

    public Guid OrderId { get; internal set; }
    public Guid InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int TotalPrice => Price * Count;


    public void ChangeCount(int newCount)
    {
        if (newCount < 1)
            return;
        Count = newCount;   
    }

    public void SetPrice(int newPrice)
    {
        Price = newPrice;   
    }
}
