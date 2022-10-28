using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.GetByPhoneNumber;

internal class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
{
    private readonly ShopDbContext _context;

    public GetUserByPhoneNumberQueryHandler(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.PhoneNumber == request.PhoneNumber,cancellationToken);

        if(user == null)
            return null;
        return await user.Map().SetUserRoleTitles(_context);
    }
}
