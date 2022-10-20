using Common.Application;
using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Roles.Edit;
public class EditRoleCommand:IBaseCommand
{
    public EditRoleCommand(Guid roleId, string title, List<Permission> permissions)
    {
        RoleId = roleId;
        Title = title;
        Permissions = permissions;
    }

    public Guid RoleId { get; set; }
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}


