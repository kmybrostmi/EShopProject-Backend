using Common.Application;
using MediatR;
using Shop.Application.Aggregates.Sellers.AddInventory;
using Shop.Application.Aggregates.Sellers.EditInventory;
using Shop.Query.Aggregates.Sellers.DTOs;
using Shop.Query.Aggregates.Sellers.Inventories.GetById;
using Shop.Query.Aggregates.Sellers.Inventories.GetByProductId;
using Shop.Query.Aggregates.Sellers.Inventories.GetList;

namespace Shop.Presentation.Facade.Aggregates.Sellers.Inventories;

public class SellerInventoryFacade:ISellerInventoryFacade
{
    private readonly IMediator _mediator;

    public SellerInventoryFacade(IMediator mediator)
	{
        _mediator = mediator;
    }

    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
        return await _mediator.Send(command); 
    }

    public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<List<InventoryDto>> GetInventories(Guid sellerId)
    {
        return await _mediator.Send(new GetInventoriesListBySellerIdQuery(sellerId));   
    }

    public async Task<InventoryDto> GetInventoryById(Guid inventoryId)
    {
        return await _mediator.Send(new GetSellerInventoryByIdQuery(inventoryId));  
    }

    public async Task<List<InventoryDto>> GetInventoryByProductId(Guid ProductId)
    {
        return await _mediator.Send(new GetInventoryByProductIdQuery(ProductId));
    }
}
