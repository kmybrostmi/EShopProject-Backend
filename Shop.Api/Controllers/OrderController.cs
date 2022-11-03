using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Orders.AddItem;
using Shop.Application.Aggregates.Orders.CheckOut;
using Shop.Application.Aggregates.Orders.DecreaseItemCount;
using Shop.Application.Aggregates.Orders.IncreaseItemCount;
using Shop.Application.Aggregates.Orders.RemoveItem;
using Shop.Presentation.Facade.Aggregates.Orders;
using Shop.Query.Aggregates.Orders.DTOs;

namespace Shop.Api.Controllers;
public class OrderController : ApiController
{
	private readonly IOrderFacade _orderFacade;

	public OrderController(IOrderFacade orderFacade)
	{
		_orderFacade = orderFacade;
	}

	[HttpGet("{orderId}")]
	public async Task<ApiResult<OrderDto?>> GetOrderById(Guid orderId)
	{
		var result = await _orderFacade.GetOrderById(orderId);
		return QueryResult(result);
	}

	[HttpGet]
	public async Task<ApiResult<OrderFilterResult>> GetOrderByFilter([FromQuery] OrderFilterParams filterParams)
	{
		var result = await _orderFacade.GetOrderByFilter(filterParams);
		return QueryResult(result);
	}

	[HttpPost]
	public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
	{
		var result = await _orderFacade.AddOrder(command);
		return CommandResult(result);	
	}

    [HttpPost("{ChechOut}")]
    public async Task<ApiResult> CheckOutOrder(CheckOutOrderCommand command)
    {
        var result = await _orderFacade.CheckOutOrder(command);
        return CommandResult(result);
    }

    [HttpPut("{orderItem/DecreaseCount}")]
    public async Task<ApiResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
    {
        var result = await _orderFacade.DecreaseOrderItemCount(command);
        return CommandResult(result);
    }

    [HttpPut("{orderItem/IncreaseCount}")]
    public async Task<ApiResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
    {
        var result = await _orderFacade.IncreaseOrderItemCount(command);
        return CommandResult(result);
    }

    [HttpDelete("{orderItem}")]
    public async Task<ApiResult> RemoveOrderItem(RemoveOrderItemCommand command)
    {
        var result = await _orderFacade.RemoveOrder(command);
        return CommandResult(result);
    }
}

