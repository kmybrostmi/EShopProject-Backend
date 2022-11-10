using Common.Query;
using Shop.Query.Aggregates.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Sellers.Inventories.GetById;
public class GetSellerInventoryByIdQuery:IQuery<InventoryDto>
{
    public GetSellerInventoryByIdQuery(Guid inventoryId)
    {
        InventoryId = inventoryId;
    }

    public Guid InventoryId { get; set; }
}


