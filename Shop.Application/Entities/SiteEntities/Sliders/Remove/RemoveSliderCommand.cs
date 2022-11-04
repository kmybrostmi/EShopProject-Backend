using Common.Application;

namespace Shop.Application.Entities.SiteEntities.Sliders.Remove;

public class RemoveSliderCommand : IBaseCommand
{
    public RemoveSliderCommand(Guid sliderId)
    {
        SliderId = sliderId;
    }

    public Guid SliderId { get; set; }
}
