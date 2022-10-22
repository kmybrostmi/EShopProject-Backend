using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Aggregates.SellerAgg.Repository;
using Shop.Domain.SellerAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef.Aggregates._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.Aggregates.SellerAgg;
internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    private readonly DapperContext _dapperContext;

    public SellerRepository(ShopDbContext context,DapperContext dapperContext) : base(context)
    {
        _dapperContext = dapperContext;
    }

    public async Task<InventoryResult?> GetInventoryById(Guid id)
    {
        using var connection = _dapperContext.GetConnection();
        var sql = $"SELECT * from {_dapperContext.Inventories} where Id=@InventoryId";

        return await connection.QueryFirstOrDefaultAsync<InventoryResult>(sql, new { InventoryId = id });
    }

    //public async Task<InventoryResult?> GetInventoryById(Guid id)
    //{
    //    return await Context.SellerInventories.Where(r => r.Id == id)
    //        .Select(i => new InventoryResult()
    //        {
    //            Count = i.Count,
    //            Id = i.Id,                                     //Have Error
    //            Price = i.Price,
    //            ProductId = i.ProductId,
    //            SellerId = i.SellerId
    //        }).FirstOrDefaultAsync();
    //}
}
