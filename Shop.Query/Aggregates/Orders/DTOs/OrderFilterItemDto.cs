using Common.Query;
using Shop.Domain.OrderAgg;

namespace Shop.Query.Aggregates.Orders.DTOs;

public class OrderFilterItemDto:BaseDto
{
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string? Shire { get; set; }
    public string? City { get; set; }
    public string? ShippingType { get; set; }
    public int TotalPrice { get; set; }
    public int TotalItemCount { get; set; }
}


