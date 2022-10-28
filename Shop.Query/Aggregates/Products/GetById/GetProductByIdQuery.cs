using Common.Query;
using Shop.Query.Aggregates.Products.DTOs;

namespace Shop.Query.Aggregates.Products.GetById;
public class GetProductByIdQuery:IQuery<ProductDto?>
{
    public GetProductByIdQuery(Guid productId)
    {
        ProductId = productId;
    }
    public Guid ProductId { get; set; }
}

