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
    public Guid UserId { get; set; }
    public Guid OrderItermId { get; set; }
}

