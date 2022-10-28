using Common.Query;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.GetById;
public class GetUserByIdQuery:IQuery<UserDto?>
{
    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}
