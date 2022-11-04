using Common.Query;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.Addresses.GetList;
public class GetUserAddressListQuery:IQuery<List<UserAddressDto>>
{
    public GetUserAddressListQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}

