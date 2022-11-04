using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Query.Aggregates.Users.Addresses.GetById;
public class GetUserAddressByIdQuery:IQuery<UserAddressDto>
{
    public GetUserAddressByIdQuery(Guid addressId)
    {
        AddressId = addressId;
    }

    public Guid AddressId { get; set; }
}
