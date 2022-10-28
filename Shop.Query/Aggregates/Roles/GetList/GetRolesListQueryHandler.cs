using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Roles.DTOs;

namespace Shop.Query.Aggregates.Roles.GetList;

internal class GetRolesListQueryHandler : IQueryHandler<GetRolesListQuery, List<RoleDto>>
{
    private readonly ShopDbContext _context;

    public GetRolesListQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<List<RoleDto>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        var roles = await _context.Roles.OrderByDescending(c => c.CreateDate).ToListAsync();
        return roles.Map();
    }
}