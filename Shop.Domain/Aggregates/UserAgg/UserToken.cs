using Common.Domain;
using Shop.Domain.OrderAgg;

namespace Shop.Domain.Aggregates.UserAgg;
public class UserToken:BaseEntity
{
    public UserToken(Guid userId, string hashJwtToken, string hashRefreshToken, DateTime jwtTokenExpireDate, 
        DateTime refreshTokenExpreDate, string device)
    {
        UserId = userId;
        HashJwtToken = hashJwtToken;
        HashRefreshToken = hashRefreshToken;
        JwtTokenExpireDate = jwtTokenExpireDate;
        RefreshTokenExpreDate = refreshTokenExpreDate;
        Device = device;
        Guard();
    }

    public Guid UserId { get; internal set; }
    public string HashJwtToken { get; private set; }
    public string HashRefreshToken { get; private set; }
    public DateTime JwtTokenExpireDate { get; private set; }
    public DateTime RefreshTokenExpreDate { get; private set; }
    public string Device { get; private set; }


    public void Guard()
    {
        NullOrEmptyDomainDataException.CheckString(HashJwtToken, nameof(HashJwtToken));
        NullOrEmptyDomainDataException.CheckString(HashRefreshToken, nameof(HashRefreshToken));

        if (JwtTokenExpireDate < DateTime.Now)
            throw new InvalidDomainDataException();

        if(JwtTokenExpireDate > RefreshTokenExpreDate)
            throw new InvalidDomainDataException();


    }
}

