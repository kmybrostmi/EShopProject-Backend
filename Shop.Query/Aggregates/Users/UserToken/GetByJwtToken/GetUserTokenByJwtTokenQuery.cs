using Common.Query;
using Shop.Query.Aggregates.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Users.UserToken.GetByJwtToken;
public class GetUserTokenByJwtTokenQuery:IQuery<UserTokenDto?>
{
    public GetUserTokenByJwtTokenQuery(string hashJwtToken)
    {
        HashJwtToken = hashJwtToken;
    }

    public string HashJwtToken { get; set; }
}
