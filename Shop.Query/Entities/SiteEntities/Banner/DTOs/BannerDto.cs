using Common.Query;
using Shop.Domain.Entities.SiteEntities.Enums;

namespace Shop.Query.Entities.SiteEntities.Banner.DTOs;
public class BannerDto:BaseDto
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public BannerPosition Position { get; set; }
}
