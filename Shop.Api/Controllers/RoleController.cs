using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Roles.Create;
using Shop.Application.Aggregates.Roles.Edit;
using Shop.Presentation.Facade.Aggregates.Roles;
using Shop.Query.Aggregates.Roles.DTOs;

namespace Shop.Api.Controllers;
public class RoleController : ApiController
{
	private readonly IRoleFacade _roleFacade;

	public RoleController(IRoleFacade roleFacade)
	{
		_roleFacade = roleFacade;
	}

	[HttpGet]
	public async Task<ApiResult<List<RoleDto>>> GetRoleList()
	{
		var result = await _roleFacade.GetRolesList();
		return QueryResult(result);
	}

    [HttpGet("{roleId}")]
    public async Task<ApiResult<RoleDto?>> GetRoleById(Guid roleId)
    {
        var result = await _roleFacade.GetRoleById(roleId);
        return QueryResult(result);
    }

	[HttpPost]
	public async Task<ApiResult> CreateRole(CreateRoleCommand command)
	{
		var result = await _roleFacade.CreateRole(command);
		return CommandResult(result);
	}

	[HttpPut]
	public async Task<ApiResult> EditRole(EditRoleCommand command)
	{
		var result = await _roleFacade.EditRole(command);
		return CommandResult(result);
	}
}

