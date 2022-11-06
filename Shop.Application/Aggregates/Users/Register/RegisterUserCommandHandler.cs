using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.Aggregates.UserAgg.Repository;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Aggregates.Users.Register;

internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUserDomainService _domainService;

    public RegisterUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }
    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var register = User.RegisterUser(request.PhoneNumber, Sha256Hasher.Hash(request.Password), _domainService);

        _repository.Add(register);
        await _repository.Save();
        return OperationResult.Success();
    }
}

