using Common.Query.Filter;

namespace Shop.Query.Aggregates.Products.DTOs;

public class ProductFilterParams : BaseFilterParam
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
}
