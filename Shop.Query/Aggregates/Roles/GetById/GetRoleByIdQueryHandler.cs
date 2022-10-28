using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Roles.DTOs;

namespace Shop.Query.Aggregates.Roles.GetById;

public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto?>
{
    private readonly ShopDbContext _context;

    public GetRoleByIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(f => f.Id == request.RoleId,cancellationToken);
        return role.Map();
    }
}