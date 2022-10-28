using Common.Query;
using Shop.Query.Aggregates.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Users.GetByPhoneNumber;
public class GetUserByPhoneNumberQuery:IQuery<UserDto?>
{
    public GetUserByPhoneNumberQuery(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public string PhoneNumber { get; set; }
}
