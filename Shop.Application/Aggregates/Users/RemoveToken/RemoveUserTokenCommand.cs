using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Users.RemoveToken;
public class RemoveUserTokenCommand : IBaseCommand
{
    public RemoveUserTokenCommand(Guid tokenId, Guid userId)
    {
        TokenId = tokenId;
        UserId = userId;
    }

    public Guid TokenId { get; set; }
    public Guid UserId { get; set; }
}

