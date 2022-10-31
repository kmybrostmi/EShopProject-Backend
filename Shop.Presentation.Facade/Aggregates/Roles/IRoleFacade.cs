using Common.Application;
using Shop.Application.Aggregates.Roles.Create;
using Shop.Application.Aggregates.Roles.Edit;
using Shop.Query.Aggregates.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Roles;

public interface IRoleFacade
{
    //Commands
    Task<OperationResult> CreateRole(CreateRoleCommand command);
    Task<OperationResult> EditRole(EditRoleCommand command);

    //Queries
    Task<RoleDto?> GetRoleById(Guid roleId);    
    Task<List<RoleDto>> GetRolesList();
}

