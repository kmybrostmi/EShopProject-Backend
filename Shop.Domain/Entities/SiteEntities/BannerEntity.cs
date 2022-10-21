using Common.Domain;
using Shop.Domain.Entities.SiteEntities.Enums;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.SiteEntities;
public class BannerEntity : BaseEntity
{
    public BannerEntity(string link, string imageName, BannerPosition bannerPosition)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        BannerPosition = bannerPosition;
    }

    public string Link { get; private set; }
    public string ImageName { get; private set; }
    public BannerPosition BannerPosition { get; private set; }

    public void Edit(string link, string imageName,BannerPosition bannerPosition)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        BannerPosition = bannerPosition;
    }


    public void Guard(string link, string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(Link, nameof(Link));
        NullOrEmptyDomainDataException.CheckString(ImageName, nameof(ImageName));
    }
}

