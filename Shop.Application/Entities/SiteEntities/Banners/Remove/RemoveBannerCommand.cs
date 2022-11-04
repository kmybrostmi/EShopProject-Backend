using Common.Application;

namespace Shop.Application.Entities.SiteEntities.Banners.Remove;

public class RemoveBannerCommand:IBaseCommand
{
    public RemoveBannerCommand(Guid bannerId)
    {
        BannerId = bannerId;
    }

    public Guid BannerId { get; set; }
}


