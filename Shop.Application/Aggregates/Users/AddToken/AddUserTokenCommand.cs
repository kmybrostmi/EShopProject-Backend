using Common.Application;

namespace Shop.Application.Aggregates.Users.AddToken;
public class AddUserTokenCommand:IBaseCommand
{
    public AddUserTokenCommand(Guid userId, string hashJwtToken, string hashRefreshToken, DateTime jwtTokenExpireDate, 
        DateTime refreshTokenExpreDate, string device)
    {
        UserId = userId;
        HashJwtToken = hashJwtToken;
        HashRefreshToken = hashRefreshToken;
        JwtTokenExpireDate = jwtTokenExpireDate;
        RefreshTokenExpreDate = refreshTokenExpreDate;
        Device = device;
    }

    public Guid UserId { get; set; }
    public string HashJwtToken { get; set; }
    public string HashRefreshToken { get; set; }
    public DateTime JwtTokenExpireDate { get; set; }
    public DateTime RefreshTokenExpreDate { get; set; }
    public string Device { get; set; }
}
