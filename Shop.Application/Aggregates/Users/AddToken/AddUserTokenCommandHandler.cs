using Common.Application;
using Shop.Domain.Aggregates.UserAgg.Repository;

namespace Shop.Application.Aggregates.Users.AddToken;

public class AddUserTokenCommandHandler : IBaseCommandHandler<AddUserTokenCommand>
{
    private readonly IUserRepository _repository;

    public AddUserTokenCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        user.AddToken(request.HashJwtToken, request.HashRefreshToken, request.JwtTokenExpireDate, request.RefreshTokenExpreDate, request.Device);
        await _repository.Save();
        return OperationResult.Success();
    }
}
