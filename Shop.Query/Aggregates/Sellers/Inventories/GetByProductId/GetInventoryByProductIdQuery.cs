using Common.Query;
using Shop.Query.Aggregates.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Sellers.Inventories.GetByProductId;
public class GetInventoryByProductIdQuery:IQuery<List<InventoryDto>>
{
    public GetInventoryByProductIdQuery(Guid productId)
    {
        ProductId = productId;
    }

    public Guid ProductId { get; set; }
}

