using Shop.Domain.Aggregates.ProductAgg.Repository;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.ProductAgg;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ShopDbContext context) : base(context)
    {
    }
}
