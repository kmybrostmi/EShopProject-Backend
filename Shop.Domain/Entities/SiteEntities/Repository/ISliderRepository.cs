using Common.Domain.Repository;


namespace Shop.Domain.Entities.SiteEntities.Repository;
public interface ISliderRepository : IBaseRepository<SliderEntity>
{
    void Delete(SliderEntity slider);
}

