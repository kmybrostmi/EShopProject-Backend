using Common.Domain;
using Shop.Domain.Entities.SiteEntities.Enums;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.SiteEntities;
public class Slider : BaseEntity
{
    public Slider(string link, string imageName, BannerPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
    }

    public string Link { get; private set; }
    public string ImageName { get; private set; }
    public BannerPosition Position { get; private set; }

    public void Edit(string link, string imageName, BannerPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
    }

    public void Guard(string link, string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(link, nameof(link));
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
    }
}

