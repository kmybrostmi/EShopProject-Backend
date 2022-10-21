using Common.Application;
using Shop.Domain.Aggregates.UserAgg.Repository;
using Shop.Domain.UserAgg;

namespace Shop.Application.Aggregates.Users.ChargeWallet;

public class ChargeUserWalletCommandHandler : IBaseCommandHandler<ChargeUserWalletCommand>
{
    private readonly IUserRepository _repository;

    public ChargeUserWalletCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(ChargeUserWalletCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var userWallet = new UserWallet(request.Price, request.Description, request.IsFinally, request.Type);

        user.ChargeWallet(userWallet);
        await _repository.Save();
        return OperationResult.Success();
    }
}




