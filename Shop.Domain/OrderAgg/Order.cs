using Common.Domain;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg;
public class Order : AggregateRoot
{
    public Order()
    {

    }
    public Order(Guid userId)
    {
        UserId = userId;
        OrderStatus = OrderStatus.Pending;
        Items = new List<OrderItem>();
    }

    public Guid UserId { get; set; }
    public OrderStatus OrderStatus { get; private set; }
    public DateTime Lastupdate { get; set; }
    public List<OrderItem> Items { get; private set; }
    public OrderDiscount? Discount { get; private set; }
    public OrderAddress? Address { get; private set; }
    public OrderShippingMethod? OrderShipping { get; private set; }
    public int TotalPrice
    {
        get
        {
            var totalPrice = Items.Sum(f => f.TotalPrice);
            if (OrderShipping != null)
                totalPrice += OrderShipping.ShippingCost;

            if (Discount != null)
                totalPrice -= Discount.DiscountAmount;

            return totalPrice;
        }
    }
    public int ItemCount => Items.Count;


    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(Guid oderItemId)
    {
        var currentItem = Items.FirstOrDefault(f=>f.Id == oderItemId);
        if(currentItem != null)
        Items.Remove(currentItem);
    }

    public void ChangeCountItem(Guid itemId, int newCount)
    {
        var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
        if (currentItem == null)
            throw new NullOrEmptyDomainDataException();

        currentItem.ChangeCount(newCount);
    }

    public void ChangeStatus(OrderStatus orderStatus)
    {
        OrderStatus = orderStatus;
        Lastupdate = DateTime.Now;
    }

    public void Checkout(OrderAddress orderAddress)
    {
        Address = orderAddress;
    }
}









