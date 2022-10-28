using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.GetById;

internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
{
    private readonly ShopDbContext _context;

    public GetUserByIdQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f=>f.Id == request.UserId,cancellationToken);

        if(user == null)
            return null;
        return await user.Map().SetUserRoleTitles(_context);
    }
}
