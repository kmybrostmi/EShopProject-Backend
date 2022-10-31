using Common.Application;
using Shop.Application.Aggregates.Sellers.AddInventory;
using Shop.Application.Aggregates.Sellers.Create;
using Shop.Application.Aggregates.Sellers.Edit;
using Shop.Application.Aggregates.Sellers.EditInventory;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Presentation.Facade.Aggregates.Sellers;
public interface ISellerFacade
{
    //Command
    Task<OperationResult> CreateSeller(CreateSellerCommand command);
    Task<OperationResult> EditSeller(EditSellerCommand command);
    Task<OperationResult> AddSellerInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditSellerInventory(EditSellerInventoryCommand command);


    //Queries
    Task<SellerDto?> GetSellerById(Guid id);
    Task<SellerFilterResult> GetSellerByFilter(SellerFilterParams filterParams);

}
