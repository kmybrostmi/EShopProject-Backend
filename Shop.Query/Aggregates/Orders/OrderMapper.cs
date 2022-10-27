
using Dapper;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Aggregates.Orders.DTOs;

namespace Shop.Query.Aggregates.Orders;
internal static class OrderMapper
{
    public static OrderDto Map(this Order order)
    {
        return new OrderDto()
        {
            CreateDate = order.CreateDate,
            Id = order.Id,
            OrderStatus = order.OrderStatus,
            Address = order.Address,
            Discount = order.Discount,
            Items = new(),
            LastUpdate = order.LastUpdate,
            OrderShipping = order.OrderShipping,
            UserFullName = "",
            UserId = order.UserId,
        };
    }

    public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto, DapperContext dapperContext)
    {
        var model = new List<OrderItemDto>();
        using var connection = dapperContext.GetConnection();
        var sql = $"SELECT o.Id, s.ShopName ,o.OrderId,o.InventoryId,o.Count,o.price," +
                       $"p.Title as ProductTitle , p.Slug as ProductSlug ,p.ImageName as ProductImageName" +
                    $" FROM {dapperContext.OrderItems} AS o " +
                    $"Inner Join {dapperContext.Inventories} AS i on o.InventoryId=i.Id" +
                    $"Inner Join {dapperContext.Products} AS p on i.ProductId=p.Id" +
                    $"Inner Join {dapperContext.Sellers} AS s on i.SellerId=s.Id" +
                    "WHERE o.OrderId = @orderId";

        var result = await connection
            .QueryAsync<OrderItemDto>(sql, new { orderId = orderDto.Id });
        return result.ToList();
    }

    public static OrderFilterItemDto MapFilterItem(this Order order, ShopDbContext context)
    {
        var userFullName = context.Users
            .Where(r => r.Id == order.UserId)
            .Select(u => $"{u.Name} {u.Family}")
            .First();

        return new OrderFilterItemDto()
        {
            OrderStatus = order.OrderStatus,
            Id = order.Id,
            CreateDate = order.CreateDate,
            City = order.Address?.City,
            ShippingType = order.OrderShipping?.ShippingType,
            Shire = order.Address?.Shire,
            TotalItemCount = order.ItemCount,
            TotalPrice = order.TotalPrice,
            UserFullName = userFullName,
            UserId = order.UserId
        };
    }

}
