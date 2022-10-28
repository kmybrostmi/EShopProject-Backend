using Shop.Domain.Entities.SiteEntities;
using Shop.Query.Aggregates.Roles.DTOs;
using Shop.Query.Entities.SiteEntities.Banner.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Entities.SiteEntities.Banner;
public static class BannerMapper
{
    public static BannerDto? Map(this BannerEntity? banner)
    {
        if (banner == null)
            return null;

        return new()
        {
            ImageName = banner.ImageName,
            Link = banner.Link,
            Position = banner.BannerPosition
        };
    }

    public static List<BannerDto> Map(this List<BannerEntity> banners)
    {
        if (banners == null)
            return null;

        var model = new List<BannerDto>();

        banners.ForEach(banner =>
        {
            model.Add(new BannerDto()
            {
                ImageName = banner.ImageName,
                Link = banner.Link,
                Position = banner.BannerPosition
            });
        });
        return model;
    }
}
