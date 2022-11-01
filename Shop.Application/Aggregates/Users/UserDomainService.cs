using Common.Domain.ValueObjects;
using Shop.Domain.Aggregates.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Users;
public class UserDomainService : IUserDomainService
{
    private readonly IUserRepository _repository;

    public UserDomainService(IUserRepository repository)
    {
        _repository = repository;
    }
    public bool IsEmailExist(string email)
    {
        return _repository.Exists(x=>x.Email == email);
    }

    public bool IsPhoneNumberExist(string phoneNumber)
    {
        return _repository.Exists(x => x.PhoneNumber == phoneNumber);
    }
}
