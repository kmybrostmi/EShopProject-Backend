using Shop.Domain.Entities.SiteEntities;
using Shop.Domain.Entities.SiteEntities.Repository;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Entitiess.SiteEntitiess.Sliders;
internal class SliderRepository : BaseRepository<SliderEntity>, ISliderRepository
{
    public SliderRepository(ShopDbContext context) : base(context)
    {
    }
}
