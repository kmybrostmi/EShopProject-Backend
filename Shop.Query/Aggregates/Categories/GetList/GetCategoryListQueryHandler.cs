using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Categories.DTOs;

namespace Shop.Query.Aggregates.Categories.GetList;

internal class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly ShopDbContext _context;

    public GetCategoryListQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories.OrderByDescending(c=>c.Id).ToListAsync();
        return result.Map();
    }
}

