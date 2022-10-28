using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Entities.SiteEntities.Slider.DTOs;

namespace Shop.Query.Entities.SiteEntities.Slider.GetList;

public class GetSlidersListQueryHandler : IQueryHandler<GetSlidersListQuery, List<SliderDto>>
{
    private readonly ShopDbContext _context;

    public GetSlidersListQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<List<SliderDto>> Handle(GetSlidersListQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Sliders.OrderByDescending(o => o.CreateDate).ToListAsync();
        return result.Map();

        //return await _context.Sliders.OrderByDescending(d => d.Id)
        //    .Select(slider => new SliderDto()
        //    {
        //        Id = slider.Id,
        //        CreationDate = slider.CreationDate,
        //        ImageName = slider.ImageName,
        //        Link = slider.Link,
        //        Title = slider.Title
        //    }).ToListAsync(cancellationToken);
    }
}
