using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.OrderAgg;
using Common.Query;

namespace Shop.Query.Aggregates.Orders.DTOs;
public class OrderDto:BaseDto
{
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime LastUpdate { get; set; }
    public List<OrderItemDto> Items { get; set; }
    public OrderAddress? Address { get; set; }
    public OrderDiscount? Discount { get; set; }
    public OrderShippingMethod? OrderShipping { get; set; }
}

