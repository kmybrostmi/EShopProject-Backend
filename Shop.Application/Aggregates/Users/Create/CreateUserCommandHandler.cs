using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.Aggregates.UserAgg.Repository;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Aggregates.Users.Create;

public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUserDomainService _domainService;

    public CreateUserCommandHandler(IUserRepository repository,IUserDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }
    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var password = Sha256Hasher.Hash(request.Password);  
        var user = new User(request.Name, request.Family, request.PhoneNumber, request.Email, password,
            request.Gender, _domainService);

        await _repository.AddAsync(user);
        await _repository.Save();
        return OperationResult.Success();
    }
}


