using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Sellers.EditInventory;
public class EditSellerInventoryCommand:IBaseCommand
{
    public EditSellerInventoryCommand(Guid sellerId, Guid inventoryId, int count, int price, int? discountPercentage)
    {
        SellerId = sellerId;
        InventoryId = inventoryId;
        Count = count;
        Price = price;
        DiscountPercentage = discountPercentage;
    }

    public Guid SellerId { get; set; }
    public Guid InventoryId { get; set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? DiscountPercentage { get; private set; }
}







