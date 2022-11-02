using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Categories.DTOs;
using Shop.Query.Aggregates.Categories.GetById;

namespace Shop.Query.Aggregates.Categories.GetByParentId;

public class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<ChildCategoryDto>>
{
    private readonly ShopDbContext _context;

    public GetCategoryByParentIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories
                                    .Include(c => c.Childs)
                                    .Where(c => c.ParentId == request.ParentId).ToListAsync(cancellationToken);
        return model.MapChildren();
    }
}


