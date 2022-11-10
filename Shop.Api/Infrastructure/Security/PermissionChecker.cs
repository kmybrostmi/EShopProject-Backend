using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Shop.Presentation.Facade.Aggregates.Users;
using Shop.Presentation.Facade.Aggregates.Roles;
using Shop.Domain.RoleAgg.Enums;

namespace Common.AspNetCore.Attributes;
public class PermissionChecker : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    private IUserFacade _userFacade;
    private IRoleFacade _roleFacade;
    private readonly Permission _permission;

    public PermissionChecker(Permission permission)
    {
        _permission = permission;
    }
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (HasAllowAnonymous(context))
            return;

        _userFacade = context.HttpContext.RequestServices.GetRequiredService<IUserFacade>();
        _roleFacade = context.HttpContext.RequestServices.GetRequiredService<IRoleFacade>();
        if (context.HttpContext.User.Identity.IsAuthenticated)
        {
            if (await UserHasPermission(context) == false)
            {
                context.Result = new ForbidResult();
            }
        }
        else
        {
            context.Result = new UnauthorizedObjectResult("Unauthorize");
        }
    }

    private async Task<bool> UserHasPermission(AuthorizationFilterContext context)
    {
        var user = await _userFacade.GetUserById(context.HttpContext.User.GetUserId());
        if (user == null)
            return false;

        var roleIds = user.Roles.Select(r => r.RoleId).ToList();
        var roles = await _roleFacade.GetRolesList();
        var userRoles = roles.Where(r => roleIds.Contains(r.Id));
        return userRoles.Any(r=>r.Permissions.Contains(_permission));
    }

    private bool HasAllowAnonymous(AuthorizationFilterContext context)
    {
        var metaData = context.ActionDescriptor.EndpointMetadata.OfType<dynamic>().ToList();
        bool hasAllowAnonymous = false;
        foreach (var f in metaData)
        {
            try
            {
                hasAllowAnonymous = f.TypeId.Name == "AllowAnonymousAttribute";
                if (hasAllowAnonymous)
                    break;
            }
            catch
            {
                // ignored
            }
        }
        return hasAllowAnonymous;
    }
}
