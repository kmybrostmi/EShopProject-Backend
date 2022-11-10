using Common.Query;
using Shop.Query.Aggregates.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Sellers.GetByUserId;
public class GetSellerByUserIdQuery:IQuery<SellerDto?>
{
    public GetSellerByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}

