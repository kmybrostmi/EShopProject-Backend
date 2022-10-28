using Common.Query;

namespace Shop.Query.Entities.SiteEntities.Slider.DTOs;
public class SliderDto:BaseDto
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string ImageName { get; set; }
}
