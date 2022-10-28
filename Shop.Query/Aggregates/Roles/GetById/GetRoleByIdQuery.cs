using Common.Query;
using Shop.Query.Aggregates.Roles.DTOs;

namespace Shop.Query.Aggregates.Roles.GetById;
public class GetRoleByIdQuery:IQuery<RoleDto?>
{
    public GetRoleByIdQuery(Guid roleId)
    {
        RoleId = roleId;
    }

    public Guid RoleId { get; set; }
}
