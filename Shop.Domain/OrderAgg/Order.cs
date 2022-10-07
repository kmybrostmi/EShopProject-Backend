using Common.Domain;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg;
public class Order : AggregateRoot
{
    public Guid UserId { get; set; }
    public OrderStatus OrderStatus { get; private set; }
    public List<OrderItem> Items { get; private set; }
    public OrderDiscount? Discount { get; private set; }
    public int TotalPrice => Items.Sum(s => s.TotalPrice);
    public int ItemCount => Items.Count;
}






