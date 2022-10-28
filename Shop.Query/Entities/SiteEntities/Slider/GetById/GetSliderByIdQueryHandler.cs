using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Entities.SiteEntities.Slider.DTOs;

namespace Shop.Query.Entities.SiteEntities.Slider.GetById;

internal class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto?>
{
    private readonly ShopDbContext _context;

    public GetSliderByIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<SliderDto?> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Sliders.FirstOrDefaultAsync(f => f.Id == request.SliderId);
        return slider.Map();

        //if (slider == null)
        //    return null;

        //return new SliderDto()
        //{
        //    Id = slider.Id,
        //    CreationDate = slider.CreationDate,
        //    ImageName = slider.ImageName,
        //    Link = slider.Link,
        //    Title = slider.Title
        //};
    }
}