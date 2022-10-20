using Common.Application;
using Shop.Domain.Aggregates.RoleAgg.Repository;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Aggregates.Roles.Edit;

internal class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
{
    private readonly IRoleRepository _repository;

    public EditRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _repository.GetTracking(request.RoleId);   
        if(role == null)    
            return OperationResult.NotFound();

        role.Edit(request.Title);

        var permissions = new List<RolePermission>();
        request.Permissions.ForEach(f =>
        {
            permissions.Add(new RolePermission(f));
        });
        role.SetPermissions(permissions);

        await _repository.Save();
        return OperationResult.Success();
    }
}



