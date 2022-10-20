using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities.SiteEntities.Enums;

namespace Shop.Application.Entities.SiteEntities.Banners.Edit;

public class EditBannerCommand:IBaseCommand
{
    public EditBannerCommand(Guid bannerId, string link, IFormFile? imageFile, BannerPosition bannerPosition)
    {
        BannerId = bannerId;
        Link = link;
        ImageFile = imageFile;
        BannerPosition = bannerPosition;
    }

    public Guid BannerId { get; set; }
    public string Link { get; set; }
    public IFormFile? ImageFile { get; set; }
    public BannerPosition BannerPosition { get; set; }
}



