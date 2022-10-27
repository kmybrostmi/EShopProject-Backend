using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Categories.DTOs;

namespace Shop.Query.Aggregates.Categories.GetById;

internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ShopDbContext _context;

    public GetCategoryByIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories.FirstOrDefaultAsync(f => f.Id == request.CategoryId,cancellationToken);
        return model.Map();
    }
}


 