using Common.Query;
using Shop.Query.Aggregates.Products.DTOs;

namespace Shop.Query.Aggregates.Products.GetBySlug;
public class GetProductBySlugQuery:IQuery<ProductDto?>
{
    public GetProductBySlugQuery(string slug)
    {
        Slug = slug;
    }

    public string Slug { get; set; }
}
