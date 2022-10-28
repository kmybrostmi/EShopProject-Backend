using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Sellers.DTOs;

namespace Shop.Query.Aggregates.Sellers.GetByFilter;

public class GetSellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
{
    private readonly ShopDbContext _context;

    public GetSellerByFilterQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;

        var result = _context.Sellers.OrderByDescending(o => o.CreateDate).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@params.NationalCode))
            result = result.Where(r => r.NationalCode.Contains(@params.NationalCode));

        if (!string.IsNullOrWhiteSpace(@params.ShopName))
            result = result.Where(r => r.ShopName.Contains(@params.ShopName));


        var skip = (@params.PageId - 1) * @params.Take;

        var sellerResult = new SellerFilterResult()
        {
            FilterParams = @params,
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(seller => seller.MapFilter())
                .ToListAsync(cancellationToken)
        };

        sellerResult.GeneratePaging(result, @params.Take, @params.PageId);
        return sellerResult;

    }
}