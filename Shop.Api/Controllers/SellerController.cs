using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Sellers.AddInventory;
using Shop.Application.Aggregates.Sellers.Create;
using Shop.Application.Aggregates.Sellers.Edit;
using Shop.Application.Aggregates.Sellers.EditInventory;
using Shop.Presentation.Facade.Aggregates.Sellers;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Api.Controllers;
public class SellerController : ApiController
{
	private readonly ISellerFacade _sellerFacade;

	public SellerController(ISellerFacade sellerFacade)
	{
		_sellerFacade = sellerFacade;
	}

	[HttpGet("{sellerId}")]
	public async Task<ApiResult<SellerDto?>> GetSellerById(Guid sellerId)
	{
		var result = await _sellerFacade.GetSellerById(sellerId);
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

	[HttpPost("Inventory")]
	public async Task<ApiResult> AddSellerInventory(AddSellerInventoryCommand command)
	{
		var result = await _sellerFacade.AddSellerInventory(command);
		return CommandResult(result);
	}

	[HttpPut] 
	public async Task<ApiResult> EditSeller(EditSellerCommand command)
	{
		var result = await _sellerFacade.EditSeller(command);
		return CommandResult(result);
	}

	[HttpPut("Inventory")]

    public async Task<ApiResult> EditSellerInventory(EditSellerInventoryCommand command)
	{
		var result = await _sellerFacade.EditSellerInventory(command);
		return CommandResult(result);
	}
}

