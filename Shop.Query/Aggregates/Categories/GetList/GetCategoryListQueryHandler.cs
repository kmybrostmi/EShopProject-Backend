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
        var result = await _context.Categories
                                .Where(c=>c.ParentId == null)
                                .Include(c=>c.Childs)
                                .ThenInclude(c=>c.Childs)
                                .OrderByDescending(c=>c.CreateDate).ToListAsync();
        return result.Map();
    }
}

