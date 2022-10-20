using Common.Application;

namespace Shop.Application.Aggregates.Products.RemoveImage;

public class RemoveProductImageCommand : IBaseCommand
{
    public RemoveProductImageCommand(Guid imageId, Guid productId)
    {
        ImageId = imageId;
        ProductId = productId;
    }

    public Guid ImageId { get; set; }
    public Guid ProductId { get; set; }
}


