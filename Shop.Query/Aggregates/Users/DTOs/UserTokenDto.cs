using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Users.DTOs;
public class UserTokenDto : BaseDto
{
    public Guid UserId { get; set; }
    public string HashJwtToken { get; set; }
    public string HashRefreshToken { get; set; }
    public DateTime JwtTokenExpireDate { get; set; }
    public DateTime RefreshTokenExpreDate { get; set; }
    public string Device { get; set; }
}

