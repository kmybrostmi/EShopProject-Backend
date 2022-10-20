using Common.Application;
using Shop.Domain.Aggregates.SellerAgg.Repository;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Aggregates.Sellers.AddInventory;

internal class AddSellerInventoryCommandHandler : IBaseCommandHandler<AddSellerInventoryCommand>
{
    private readonly ISellerRepository _repository;

    public AddSellerInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();

        var addInventory = new SellerInventory(request.ProductId, request.Count, request.Price, request.DiscountPercentage);
        seller.AddInventory(addInventory);
        await _repository.AddAsync(seller);
        return OperationResult.Success();
    }
}
