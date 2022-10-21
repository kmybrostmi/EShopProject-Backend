using Shop.Domain.Aggregates.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.CategoryAgg;
internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ShopDbContext context) : base(context)
    {
    }
}
