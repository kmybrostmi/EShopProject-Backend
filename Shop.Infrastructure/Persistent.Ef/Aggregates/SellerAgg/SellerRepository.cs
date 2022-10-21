using Microsoft.EntityFrameworkCore;
using Shop.Domain.Aggregates.SellerAgg.Repository;
using Shop.Domain.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.SellerAgg;
internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    public SellerRepository(ShopDbContext context) : base(context)
    {
    }

    public async Task<InventoryResult?> GetInventoryById(Guid id)
    {
        return await Context.SellerInventories.Where(r => r.Id == id)
            .Select(i => new InventoryResult()
            {
                Count = i.Count,
                Id = i.Id,
                Price = i.Price,
                ProductId = i.ProductId,
                SellerId = i.SellerId
            }).FirstOrDefaultAsync();
    }
}
