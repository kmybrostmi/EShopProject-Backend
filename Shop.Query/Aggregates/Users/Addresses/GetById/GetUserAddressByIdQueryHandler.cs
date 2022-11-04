using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.Addresses.GetById;

public class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, UserAddressDto?>
{
    private readonly DapperContext _dapperContext;

    public GetUserAddressByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<UserAddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var sql = $"Select top 1 * from {_dapperContext.UserAddresses} where id=@id";
        using var context = _dapperContext.GetConnection();
        return await context.QueryFirstOrDefaultAsync<UserAddressDto>(sql, new { id = request.AddressId });
    }
}
