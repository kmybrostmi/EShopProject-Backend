using Common.Query;
using Shop.Query.Aggregates.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Sellers.GetById;
public class GetSellerByIdQuery:IQuery<SellerDto?>
{
    public GetSellerByIdQuery(Guid sellerId)
    {
        SellerId = sellerId;
    }

    public Guid SellerId { get; set; }
}
