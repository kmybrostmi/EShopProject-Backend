using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Orders.IncreaseItemCount;
public class IncreaseOrderItemCountCommand:IBaseCommand
{
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
    public int Count { get; set; }
}

