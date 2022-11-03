using Common.Application;
using Shop.Application.Aggregates.Orders.AddItem;
using Shop.Application.Aggregates.Orders.CheckOut;
using Shop.Application.Aggregates.Orders.DecreaseItemCount;
using Shop.Application.Aggregates.Orders.IncreaseItemCount;
using Shop.Application.Aggregates.Orders.RemoveItem;
using Shop.Query.Aggregates.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Orders;
public interface IOrderFacade
{
    //Commands
    Task<OperationResult> AddOrder(AddOrderItemCommand command); 
    Task<OperationResult> CheckOutOrder(CheckOutOrderCommand command); 
    Task<OperationResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command); 
    Task<OperationResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command); 
    Task<OperationResult> RemoveOrder(RemoveOrderItemCommand command); 


    //Queries
    Task<OrderDto?> GetOrderById(Guid id);   
    Task<OrderFilterResult> GetOrderByFilter(OrderFilterParams filterParams);
    
}
