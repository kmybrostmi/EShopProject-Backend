using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.Addresses.GetList;

public class GetUserAddressListQueryHandler : IQueryHandler<GetUserAddressListQuery, List<UserAddressDto>>
{
    private readonly DapperContext _dapperContext;

    public GetUserAddressListQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<List<UserAddressDto>> Handle(GetUserAddressListQuery request, CancellationToken cancellationToken)
    {
        var sql = $"Select * from {_dapperContext.UserAddresses} where UserId=@userId";
        using var context = _dapperContext.GetConnection();
        var result = await context.QueryFirstOrDefaultAsync<List<UserAddressDto>>(sql, new { id = request.UserId });
        return result.ToList();
    }
}

