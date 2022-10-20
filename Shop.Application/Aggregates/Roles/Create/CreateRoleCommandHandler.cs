using Common.Application;
using Shop.Domain.Aggregates.RoleAgg.Repository;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Aggregates.Roles.Create;

public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _repository;

    public CreateRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var permission = new List<RolePermission>();
        request.Permissions.ForEach(f =>
        {
            permission.Add(new RolePermission(f));

        });

        var role = new Role(request.Title,permission);
        await _repository.AddAsync(role);
        await _repository.Save();
        return OperationResult.Success();

    }
}

