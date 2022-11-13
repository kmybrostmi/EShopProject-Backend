using Common.Query;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Query.Aggregates.Sellers.Inventories.GetById;

internal class GetSellerInventoryByIdQueryHandler : IQueryHandler<GetSellerInventoryByIdQuery, InventoryDto>
{
    private readonly DapperContext _dapperContext;

    public GetSellerInventoryByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<InventoryDto> Handle(GetSellerInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.GetConnection();

        var sql = @$"SELECT Top(1) i.Id, i.SellerId , i.ProductId ,i.Count , i.Price,i.CreateDate , i.DiscountPercentage , s.ShopName,
                        p.Title as ProductTitle,p.ImageName as ProductImage
            FROM 
        {_dapperContext.Inventories} i inner join {_dapperContext.Sellers} s on i.SellerId=s.Id  
            inner join {_dapperContext.Products} p on i.ProductId=p.Id WHERE i.Id=@id";

        var inventory = await connection.QueryFirstOrDefaultAsync<InventoryDto>(sql, new { id = request.InventoryId });

        return inventory;
    }
}


