using Common.Application;
using MediatR;
using Shop.Application.Aggregates.Orders.AddItem;
using Shop.Application.Aggregates.Orders.CheckOut;
using Shop.Application.Aggregates.Orders.DecreaseItemCount;
using Shop.Application.Aggregates.Orders.IncreaseItemCount;
using Shop.Application.Aggregates.Orders.RemoveItem;
using Shop.Query.Aggregates.Orders.DTOs;
using Shop.Query.Aggregates.Orders.GetByFilter;
using Shop.Query.Aggregates.Orders.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Orders;
public class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;

    public OrderFacade(IMediator mediator)
    {
       _mediator = mediator;
    }
    public Task<OperationResult> AddOrder(AddOrderItemCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<OperationResult> CheckOutOrder(CheckOutOrderCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<OperationResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<OrderFilterResult> GetOrderByFilter(OrderFilterParams filterParams)
    {
        return _mediator.Send(new GetOrdersByFilterQuery(filterParams));
    }

    public Task<OrderDto?> GetOrderById(Guid id)
    {
        return _mediator.Send(new GetOrderByIdQuery(id));
    }

    public Task<OperationResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<OperationResult> RemoveOrder(RemoveOrderItemCommand command)
    {
        return _mediator.Send(command);
    }
}
