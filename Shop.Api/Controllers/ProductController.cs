using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Products.AddImage;
using Shop.Application.Aggregates.Products.Create;
using Shop.Application.Aggregates.Products.Edit;
using Shop.Application.Aggregates.Products.RemoveImage;
using Shop.Presentation.Facade.Aggregates.Products;
using Shop.Query.Aggregates.Products.DTOs;

namespace Shop.Api.Controllers;
public class ProductController : ApiController
{
	private readonly IProductFacade _productFacade;

	public ProductController(IProductFacade productFacade)
	{
		_productFacade = productFacade;
	}

	[HttpGet("{productId}")]
	public async Task<ApiResult<ProductDto?>> GetProductById(Guid productId)
	{
		var result = await _productFacade.GetProductById(productId);
		return QueryResult(result);
	}

	[HttpGet("{slug}")]
	public async Task<ApiResult<ProductDto?>> GetProductBySlugName(string slug)
	{
		var result = await _productFacade.GetProductBySlug(slug);
		return QueryResult(result);
	}

	[HttpGet]
	public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
	{
		var result = await _productFacade.GetProductByFilter(filterParams);
		return QueryResult(result);
	}

	[HttpPost]
	public async Task<ApiResult> CreateProduct([FromForm] CreateProductCommand command)
	{
		var result = await _productFacade.CreateProduct(command);
		return CommandResult(result);
	}

	[HttpPost("images")]
	public async Task<ApiResult> AddProductImage([FromForm] AddProductImageCommand command)
	{
		var result = await _productFacade.AddProductImage(command);
		return CommandResult(result);
	}

	[HttpPut]
	public async Task<ApiResult> EditProduct([FromForm] EditProductCommand command)
	{
		var result = await _productFacade.EditProduct(command);
		return CommandResult(result);
	}

	[HttpDelete("images")]
	public async Task<ApiResult> RemoveProductImage(RemoveProductImageCommand command)
	{
		var result = await _productFacade.RemoveProductImage(command);
		return CommandResult(result);
	}
}

