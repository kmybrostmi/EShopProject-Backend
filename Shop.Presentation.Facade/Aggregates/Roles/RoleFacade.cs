using Common.Application;
using MediatR;
using Shop.Application.Aggregates.Roles.Create;
using Shop.Application.Aggregates.Roles.Edit;
using Shop.Query.Aggregates.Roles.DTOs;
using Shop.Query.Aggregates.Roles.GetById;
using Shop.Query.Aggregates.Roles.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Roles
{
    public class RoleFacade : IRoleFacade
    {
        private readonly IMediator _mediator;

        public RoleFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> CreateRole(CreateRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditRole(EditRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<RoleDto?> GetRoleById(Guid roleId)
        {
            return await _mediator.Send(new GetRoleByIdQuery(roleId));
        }

        public async Task<List<RoleDto>> GetRolesList()
        {
            return await _mediator.Send(new GetRolesListQuery());
        }
    }
}
