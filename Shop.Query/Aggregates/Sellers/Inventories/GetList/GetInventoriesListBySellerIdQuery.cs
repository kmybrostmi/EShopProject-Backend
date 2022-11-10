using Common.Query;
using Shop.Query.Aggregates.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Sellers.Inventories.GetList;
public class GetInventoriesListBySellerIdQuery:IQuery<List<InventoryDto>>
{
    public GetInventoriesListBySellerIdQuery(Guid sellerId)
    {
        SellerId = sellerId;
    }

    public Guid SellerId { get; set; }
}

