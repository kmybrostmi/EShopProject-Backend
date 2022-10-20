using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.SiteEntities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Entities.SiteEntities.Banners.Create;
public class CreateBannerCommand:IBaseCommand
{
    public CreateBannerCommand(string link, IFormFile imageFile, BannerPosition position)
    {
        Link = link;
        ImageFile = imageFile;
        BannerPosition = position;
    }

    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public BannerPosition BannerPosition { get; set; }
}


