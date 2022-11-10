using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Query.Aggregates.Sellers.GetByUserId;

internal class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
{
    private readonly ShopDbContext _context;

    public GetSellerByUserIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Sellers.FirstOrDefaultAsync(f=>f.UserId == request.UserId,cancellationToken);
        return seller.Map();
    }
}

