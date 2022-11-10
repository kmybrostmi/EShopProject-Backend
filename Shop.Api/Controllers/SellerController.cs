using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Sellers.AddInventory;
using Shop.Application.Aggregates.Sellers.Create;
using Shop.Application.Aggregates.Sellers.Edit;
using Shop.Application.Aggregates.Sellers.EditInventory;
using Shop.Presentation.Facade.Aggregates.Sellers;
using Shop.Presentation.Facade.Aggregates.Sellers.Inventories;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Api.Controllers;
public class SellerController : ApiController
{
	private readonly ISellerFacade _sellerFacade;
    private readonly ISellerInventoryFacade _sellerInventoryFacade;

    public SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade sellerInventoryFacade)
	{
		_sellerFacade = sellerFacade;
        _sellerInventoryFacade = sellerInventoryFacade;
    }

	[HttpGet("{sellerId}")]
	public async Task<ApiResult<SellerDto?>> GetSellerById(Guid sellerId)
	{
		var result = await _sellerFacade.GetSellerById(sellerId);
		return QueryResult(result);
	}

	[HttpGet("{current}")]
	public async Task<ApiResult<SellerDto?>> GetSeller()
	{
		var result = await _sellerFacade.GetSellerByUserId(User.GetUserId());
		return QueryResult(result);
	}

	[HttpGet]
	public async Task<ApiResult<SellerFilterResult>> GetSellerByFilter([FromQuery] SellerFilterParams filterParams)
	{
		var result = await _sellerFacade.GetSellerByFilter(filterParams);
		return QueryResult(result);
	}

	[HttpPost]
	public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
	{
		var result = await _sellerFacade.CreateSeller(command);
		return CommandResult(result);
	}

	[HttpPut] 
	public async Task<ApiResult> EditSeller(EditSellerCommand command)
	{
		var result = await _sellerFacade.EditSeller(command);
		return CommandResult(result);
	}


    [HttpPost("Inventory")]
    public async Task<ApiResult> AddSellerInventory(AddSellerInventoryCommand command)
    {
        var result = await _sellerFacade.AddSellerInventory(command);
        return CommandResult(result);
    }

    [HttpPut("Inventory")]
	public async Task<ApiResult> EditSellerInventory(EditSellerInventoryCommand command)
	{
		var result = await _sellerFacade.EditSellerInventory(command);
		return CommandResult(result);
	}

	[HttpGet("Inventory")]
	public async Task<ApiResult<List<InventoryDto>>> GetInventories()
	{
		var seller = await _sellerFacade.GetSellerByUserId(User.GetUserId());	
		if (seller == null)
                return QueryResult(new List<InventoryDto>());

		var result = await _sellerInventoryFacade.GetInventories(seller.Id);
		return QueryResult(result);
    }

    [HttpGet("Inventory/{inventoryId}")]
	public async Task<ApiResult<InventoryDto>> GetInventoryById(Guid inventoryId)
	{
        var seller = await _sellerFacade.GetSellerByUserId(User.GetUserId());
        if (seller == null)
            return QueryResult(new InventoryDto());

		var result = await _sellerInventoryFacade.GetInventoryById(inventoryId);
		if(result == null || result.SellerId != seller.Id)
            return QueryResult(new InventoryDto());

        return QueryResult(result);
    }

    [HttpGet("Inventory/{productId}")]
	public async Task<ApiResult<List<InventoryDto>>> GetInventoryByProductId(Guid productId)
	{
		var result = await _sellerInventoryFacade.GetInventoryByProductId(productId);
		return QueryResult(result);
	}
}

