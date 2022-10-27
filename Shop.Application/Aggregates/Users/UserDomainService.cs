using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Users;
public class UserDomainService : IUserDomainService
{
    public bool IsEmailExist(string email)
    {
        throw new NotImplementedException();
    }

    public bool IsPhoneNumberExist(PhoneNumber phoneNumber)
    {
        throw new NotImplementedException();
    }
}
