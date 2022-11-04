using Shop.Domain.Entities.SiteEntities;
using Shop.Domain.Entities.SiteEntities.Repository;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.Entitiess.SiteEntitiess.Banners;
internal class BannerRepository : BaseRepository<BannerEntity>, IBannerRepository
{
    public BannerRepository(ShopDbContext context) : base(context)
    {
    }

    public void Delete(BannerEntity banner)
    {
        Context.Banners.Remove(banner);
    }
}
