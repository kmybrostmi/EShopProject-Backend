using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Entities.SiteEntities.Banners.Create;
using Shop.Application.Entities.SiteEntities.Banners.Edit;
using Shop.Application.Entities.SiteEntities.Banners.Remove;
using Shop.Presentation.Facade.Entities.SiteEntities.Banners;
using Shop.Query.Entities.SiteEntities.Banner.DTOs;

namespace Shop.Api.Controllers;
public class BannerController : ApiController
{
	private readonly IBannerFacade _bannerFacade;

	public BannerController(IBannerFacade bannerFacade)
	{
		_bannerFacade = bannerFacade;
	}

	[HttpGet]
	public async Task<ApiResult<List<BannerDto>>> GetBannersList()
	{
		var result = await _bannerFacade.GetBannersList();
		return QueryResult(result);
	}

	[HttpGet("{bannerId}")]
	public async Task<ApiResult<BannerDto?>> GetBannerById(Guid bannerId)
	{
		var result = await _bannerFacade.GetBannerById(bannerId);
		return QueryResult(result);
	}

	[HttpPost]
	public async Task<ApiResult> CreateBanner(CreateBannerCommand command)
	{
		var result = await _bannerFacade.CreateBanner(command);
		return CommandResult(result);
	}

	[HttpPut]
	public async Task<ApiResult> EditBanner(EditBannerCommand command)
	{
		var result = await _bannerFacade.EditBanner(command);
		return CommandResult(result);
	}

	[HttpDelete("{bannerId}")]
	public async Task<ApiResult> RemoveBanner(Guid bannerId)
	{
		var result = await _bannerFacade.RemoveBanner(bannerId);
		return CommandResult(result);
	}
}

