using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Orders.RemoveItem;
public class RemoveOrderItemCommand:IBaseCommand
{
    public RemoveOrderItemCommand(Guid userId, Guid orderItermId)
    {
        UserId = userId;
        OrderItermId = orderItermId;
    }

    public Guid UserId { get; set; }
    public Guid OrderItermId { get; set; }
}

