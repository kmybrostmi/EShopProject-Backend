﻿using Common.Query;

namespace Shop.Query.Aggregates.Orders.DTOs;

public class OrderItemDto:BaseDto
{
    public string ProductTitle { get; set; }
    public string ProductSlug { get; set; }
    public string ProductImageName { get; set; }
    public string ShopName { get; set; }
    public Guid OrderId { get; set; }
    public Guid InventoryId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int TotalPrice => Price * Count;
}

