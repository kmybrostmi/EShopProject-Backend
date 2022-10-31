using Common.Application;
using Shop.Application.Entities.SiteEntities.Sliders.Create;
using Shop.Application.Entities.SiteEntities.Sliders.Edit;
using Shop.Application.Entities.SiteEntities.Sliders.Remove;
using Shop.Query.Entities.SiteEntities.Slider.DTOs;

namespace Shop.Presentation.Facade.Entities.SiteEntities.Sliders;

public interface ISliderFacade
{
    //Commands
    Task<OperationResult> CreateSlider(CreateSliderCommand command);
    Task<OperationResult> EditSlider(EditSliderCommand command);
    Task<OperationResult> RemoveSlider(RemoveSliderCommand command);


    //Queries
    Task<SliderDto?> GetSliderById(Guid id);
    Task<List<SliderDto>> GetSlidersList();


}

