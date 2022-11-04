using Common.Application;
using MediatR;
using Shop.Application.Entities.SiteEntities.Sliders.Create;
using Shop.Application.Entities.SiteEntities.Sliders.Edit;
using Shop.Application.Entities.SiteEntities.Sliders.Remove;
using Shop.Query.Entities.SiteEntities.Slider.DTOs;
using Shop.Query.Entities.SiteEntities.Slider.GetById;
using Shop.Query.Entities.SiteEntities.Slider.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Entities.SiteEntities.Sliders;
public class SliderFacade : ISliderFacade
{
    private readonly IMediator _mediator;

    public SliderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateSlider(CreateSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSlider(EditSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<SliderDto?> GetSliderById(Guid id)
    {
        return await _mediator.Send(new GetSliderByIdQuery(id));
    }

    public async Task<List<SliderDto>> GetSlidersList()
    {
        return await _mediator.Send(new GetSlidersListQuery());
    }

    public async Task<OperationResult> RemoveSlider(Guid sliderId)
    {
        return await _mediator.Send(new RemoveSliderCommand(sliderId));
    }
}

