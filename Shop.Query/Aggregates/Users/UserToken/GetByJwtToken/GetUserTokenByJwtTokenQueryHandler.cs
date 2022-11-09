using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.UserToken.GetByJwtToken;

public class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto?>
{
    private readonly DapperContext _dapperContext;

    public GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<UserTokenDto?> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.GetConnection();
        var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserToken} Where HashJwtToken=@hashJwtToken";
        return await connection.QueryFirstOrDefaultAsync(sql, new { hashJwtToken = request.HashJwtToken });
    }
}
