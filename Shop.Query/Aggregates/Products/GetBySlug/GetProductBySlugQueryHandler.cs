using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Products.DTOs;

namespace Shop.Query.Aggregates.Products.GetBySlug;

public class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto?>
{
    private readonly ShopDbContext _context;

    public GetProductBySlugQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<ProductDto?> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(f => f.Slug == request.Slug,cancellationToken);

        var model = product.Map();

        if (model == null)
            return null;

        await model.SetCategories(_context);
        return model;
    }
}
