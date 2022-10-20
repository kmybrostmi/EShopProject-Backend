﻿using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Orders.DecreaseItemCount;
public class DecreaseOrderItemCountCommand:IBaseCommand
{
    public DecreaseOrderItemCountCommand(Guid userId, Guid itemId, int count)
    {
        UserId = userId;
        ItemId = itemId;
        Count = count;
    }

    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
    public int Count { get; set; }
}
