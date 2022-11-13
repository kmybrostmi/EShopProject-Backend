using Common.Query;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Query.Aggregates.Sellers.Inventories.GetByProductId;

public class GetInventoryByProductIdQueryHandler : IQueryHandler<GetInventoryByProductIdQuery, List<InventoryDto>>
{
    private readonly DapperContext _dapperContext;

    public GetInventoryByProductIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<List<InventoryDto>> Handle(GetInventoryByProductIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.GetConnection();
        var sql = @$"SELECT i.Id, i.SellerId , i.ProductId ,i.Count , i.Price ,i.CreateDate , i.DiscountPercentage , s.ShopName ,
                        p.Title as ProductTitle,p.ImageName as ProductImage
            FROM 
        {_dapperContext.Inventories} i inner join {_dapperContext.Sellers} s on i.SellerId=s.Id  
            inner join {_dapperContext.Products} p on i.ProductId=p.Id WHERE ProductId=@productId";
        var result = await connection.QueryAsync<InventoryDto>(sql, new { productId = request.ProductId });
        return result.ToList();
    }
}



