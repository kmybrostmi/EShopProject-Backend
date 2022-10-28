using Common.Query;
using Shop.Query.Entities.SiteEntities.Banner.DTOs;

namespace Shop.Query.Entities.SiteEntities.Banner.GetById;
public class GetBannerByIdQuery:IQuery<BannerDto?>
{
    public GetBannerByIdQuery(Guid bannerId)
    {
        BannerId = bannerId;
    }

    public Guid BannerId { get; set; }
}
