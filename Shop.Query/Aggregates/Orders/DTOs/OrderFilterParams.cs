using Common.Query.Filter;
using Shop.Domain.OrderAgg;

namespace Shop.Query.Aggregates.Orders.DTOs;

public class OrderFilterParams:BaseFilterParam
{
    public Guid? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatus? Status { get; set; }
}
