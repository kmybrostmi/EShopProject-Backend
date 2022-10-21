using Shop.Domain.Aggregates.SellerAgg.Repository;
using Shop.Domain.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.SellerAgg;
internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    public SellerRepository(ShopDbContext context) : base(context)
    {
    }

    public Task<InventoryResult> GetInventoryById(Guid id)
    {
        throw new NotImplementedException();
    }
}
