using Common.Query;
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
    public Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

 