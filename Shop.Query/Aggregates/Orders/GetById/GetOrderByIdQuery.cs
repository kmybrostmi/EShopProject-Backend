using Common.Query;
using Shop.Query.Aggregates.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Orders.GetById;
public class GetOrderByIdQuery:IQuery<OrderDto?>
{
    public Guid OrderId { get; set; }

    public GetOrderByIdQuery(Guid orderId)
    {
        OrderId = orderId;
    }
}

