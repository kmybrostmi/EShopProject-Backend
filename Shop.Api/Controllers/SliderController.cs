using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Sellers.Create;
using Shop.Application.Entities.SiteEntities.Sliders.Create;
using Shop.Application.Entities.SiteEntities.Sliders.Edit;
using Shop.Presentation.Facade.Entities.SiteEntities.Sliders;
using Shop.Query.Entities.SiteEntities.Slider.DTOs;

namespace Shop.Api.Controllers;

public class SliderController : ApiController
{
	//private readonly ISliderFacade _sliderFacade;

	//public SliderController(ISliderFacade sliderFacade)
	//{
	//	_sliderFacade = sliderFacade;
	//}

	//[HttpGet]
	//public async Task<ApiResult<List<SliderDto>>> GetSliderList()
	//{
	//	var result = await _sliderFacade.GetSlidersList();
	//	return QueryResult(result);
	//}

	//[HttpGet("{sliderId}")]
	//public async Task<ApiResult<SliderDto?>> GetSliderById(Guid sliderId)
	//{
	//	var result = await _sliderFacade.GetSliderById(sliderId);
	//	return QueryResult(result);
	//}

	//[HttpPost]
	//public async Task<ApiResult> CreateSlider(CreateSliderCommand command)
	//{
	//	var result = await _sliderFacade.CreateSlider(command);
	//	return CommandResult(result);
	//}

	//[HttpPost]
	//public async Task<ApiResult> EditSlider(EditSliderCommand command)
	//{
	//	var result = await _sliderFacade.EditSlider(command);
	//	return CommandResult(result);
	//}

	//[HttpDelete("{sliderId}")]
	//public async Task<ApiResult> RemoveSlider(Guid sliderId)
	//{
	//	var result = await _sliderFacade.RemoveSlider(sliderId);
	//	return CommandResult(result);
	//}
}

