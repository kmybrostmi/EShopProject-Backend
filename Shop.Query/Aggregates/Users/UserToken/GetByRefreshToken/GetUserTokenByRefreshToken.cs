using Common.Query;
using Shop.Query.Aggregates.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Users.UserToken.GetByRefreshToken;
public class GetUserTokenByRefreshToken:IQuery<UserTokenDto?>
{
    public GetUserTokenByRefreshToken(string hashRefreshToken)
    {
        HashRefreshToken = hashRefreshToken;
    }

    public string HashRefreshToken { get; set;} 
}

