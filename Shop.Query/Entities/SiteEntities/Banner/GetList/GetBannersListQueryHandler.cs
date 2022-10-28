using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Entities.SiteEntities.Banner.DTOs;

namespace Shop.Query.Entities.SiteEntities.Banner.GetList;

internal class GetBannersListQueryHandler : IQueryHandler<GetBannersListQuery, List<BannerDto>>
{
    private readonly ShopDbContext _context;

    public GetBannersListQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<List<BannerDto>> Handle(GetBannersListQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Banners.OrderByDescending(o => o.CreateDate).ToListAsync();
        return result.Map();

        //return await _context.Banners.OrderByDescending(d => d.Id)
        //    .Select(banner => new BannerDto()
        //    {
        //        Id = banner.Id,
        //        CreationDate = banner.CreationDate,
        //        ImageName = banner.ImageName,
        //        Link = banner.Link,
        //        Position = banner.Position
        //    }).ToListAsync(cancellationToken);

    }
}
