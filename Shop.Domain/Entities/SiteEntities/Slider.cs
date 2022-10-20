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
    public Slider(string title,string link, string imageName)
    {
        Guard(title,link, imageName);
        Link = link;
        ImageName = imageName;
        Title = title;
    }

    public string Link { get; private set; }
    public string ImageName { get; private set; }
    public string Title { get; private set; }

    public void Edit(string title,string link, string imageName)
    {
        Guard(title,link, imageName);
        Link = link;
        ImageName = imageName;
        Title = title;
    }

    public void Guard(string title,string link, string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(link, nameof(link));
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
    }
}

