using Common.Application;
using Shop.Application.Aggregates.Sellers.AddInventory;
using Shop.Application.Aggregates.Sellers.EditInventory;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Presentation.Facade.Aggregates.Sellers.Inventories;
public interface ISellerInventoryFacade
{
    //Commands
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);


    //Queries
    Task<InventoryDto> GetInventoryById(Guid inventoryId);
    Task<List<InventoryDto>> GetInventories(Guid sellerId);
    Task<List<InventoryDto>> GetInventoryByProductId(Guid ProductId);

}
