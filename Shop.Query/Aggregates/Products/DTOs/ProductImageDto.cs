using Common.Query;

namespace Shop.Query.Aggregates.Products.DTOs;

public class ProductImageDto : BaseDto
{
    public Guid ProductId { get; set; }
    public string ImageName { get; set; }
    public int Sequence { get; set; }
}
