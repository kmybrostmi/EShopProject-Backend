using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Entities.SiteEntities.Banner.DTOs;

namespace Shop.Query.Entities.SiteEntities.Banner.GetById;

public class GetBannerByIdQueryHandler : IQueryHandler<GetBannerByIdQuery, BannerDto?>
{
    private readonly ShopDbContext _context;

    public GetBannerByIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<BannerDto?> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
    {
        var banner = await _context.Banners.FirstOrDefaultAsync(f => f.Id == request.BannerId, cancellationToken);
        return banner.Map();

        //if (banner == null)
        //    return null;

        //return new BannerDto()
        //{
        //    Id = banner.Id,
        //    CreationDate = banner.CreationDate,
        //    ImageName = banner.ImageName,
        //    Link = banner.Link,
        //    Position = banner.Position
        //};
    }
}
