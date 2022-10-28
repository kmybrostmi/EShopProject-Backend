using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Query.Aggregates.Sellers.GetById;

public class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto?>
{
    private readonly ShopDbContext _context;

    public GetSellerByIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Sellers.FirstOrDefaultAsync(f => f.Id == request.SellerId,cancellationToken);
        return seller.Map();
    }
}
