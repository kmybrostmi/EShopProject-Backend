using Common.Application;
using Shop.Domain.Aggregates.UserAgg.Repository;
using Shop.Domain.UserAgg;

namespace Shop.Application.Aggregates.Users.EditAddress;

internal class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
{
    private readonly IUserRepository _repository;

    public EditUserAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress,
            request.PhoneNumber, request.Name, request.Family, request.NationalCode);

        user.EditAddress(address, request.AddressId);
        await _repository.Save();
        return OperationResult.Success();
    }
}
