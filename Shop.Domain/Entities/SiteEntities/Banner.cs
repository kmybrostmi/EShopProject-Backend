using Common.Domain;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.SiteEntities;
public class Banner : BaseEntity
{
    public Banner(string title, string link, string imageName)
    {
        Guard(title, link, imageName);
        Title = title;
        Link = link;
        ImageName = imageName;
    }

    public string Title { get; private set; }
    public string Link { get; private set; }
    public string ImageName { get; private set; }

    public void Edit(string title, string link, string imageName)
    {
        Guard(title, link, imageName);
        Title = title;
        Link = link;
        ImageName = imageName;
    }


    public void Guard(string title, string link, string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(Title, nameof(Title));
        NullOrEmptyDomainDataException.CheckString(Link, nameof(Link));
        NullOrEmptyDomainDataException.CheckString(ImageName, nameof(ImageName));
    }
}
