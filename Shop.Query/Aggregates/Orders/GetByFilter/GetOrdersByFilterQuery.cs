using Common.Query;
using Shop.Query.Aggregates.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Orders.GetByFilter;
public class GetOrdersByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrdersByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
    {
    }
}

