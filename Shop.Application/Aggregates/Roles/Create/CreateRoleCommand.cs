using Common.Application;
using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Roles.Create;
public class CreateRoleCommand:IBaseCommand
{
    public CreateRoleCommand(string title, List<Permission> permissions)
    {
        Title = title;
        Permissions = permissions;
    }

    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}

