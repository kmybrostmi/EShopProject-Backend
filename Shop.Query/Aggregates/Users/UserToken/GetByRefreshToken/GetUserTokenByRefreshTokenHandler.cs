using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.UserToken.GetByRefreshToken;

public class GetUserTokenByRefreshTokenHandler : IQueryHandler<GetUserTokenByRefreshToken, UserTokenDto?>
{
    private readonly DapperContext _dapperContext;

    public GetUserTokenByRefreshTokenHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<UserTokenDto?> Handle(GetUserTokenByRefreshToken request, CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.GetConnection();
        var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserToken} WHERE HashRefreshToken=@hashRefreshToken";
        return await connection.QueryFirstOrDefaultAsync(sql, new { hashRefreshToken = request.HashRefreshToken });
    }
}
