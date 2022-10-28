using Common.Query;
using Shop.Query.Entities.SiteEntities.Slider.DTOs;

namespace Shop.Query.Entities.SiteEntities.Slider.GetById;
public class GetSliderByIdQuery:IQuery<SliderDto?>
{
    public GetSliderByIdQuery(Guid sliderId)
    {
        SliderId = sliderId;
    }

    public Guid SliderId { get; set; }
}
