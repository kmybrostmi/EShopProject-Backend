using Common.Domain;
using Shop.Domain.OrderAgg;

namespace Shop.Domain.Aggregates.UserAgg;
public class UserToken:BaseEntity
{
    private UserToken()
    {

    }
    public UserToken(string hashJwtToken, string hashRefreshToken, DateTime jwtTokenExpireDate, 
        DateTime refreshTokenExpreDate, string device)
    {
        Guard(hashJwtToken, hashRefreshToken, jwtTokenExpireDate, refreshTokenExpreDate, device);
        HashJwtToken = hashJwtToken;
        HashRefreshToken = hashRefreshToken;
        JwtTokenExpireDate = jwtTokenExpireDate;
        RefreshTokenExpreDate = refreshTokenExpreDate;
        Device = device;
    }

    public Guid UserId { get; internal set; }
    public string HashJwtToken { get; private set; }
    public string HashRefreshToken { get; private set; }
    public DateTime JwtTokenExpireDate { get; private set; }
    public DateTime RefreshTokenExpreDate { get; private set; }
    public string Device { get; private set; }


    public void Guard(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
    {
        NullOrEmptyDomainDataException.CheckString(hashJwtToken, nameof(HashJwtToken));
        NullOrEmptyDomainDataException.CheckString(hashRefreshToken, nameof(HashRefreshToken));

        if (tokenExpireDate < DateTime.Now)
            throw new InvalidDomainDataException("Invalid Token ExpireDate");

        if (refreshTokenExpireDate < tokenExpireDate)
            throw new InvalidDomainDataException("Invalid RefreshToken ExpireDate");
    }
}

