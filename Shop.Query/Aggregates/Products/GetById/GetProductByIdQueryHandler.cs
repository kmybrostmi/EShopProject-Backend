using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Products.DTOs;

namespace Shop.Query.Aggregates.Products.GetById;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly ShopDbContext _context;

    public GetProductByIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(f => f.Id == request.ProductId,cancellationToken);

        var model = product.Map();
        if (model == null)
            return null;
        await model.SetCategories(_context);
        return model;
    }
}

