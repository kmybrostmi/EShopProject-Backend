using Common.Domain;
using Shop.Domain.OrderAgg;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg;
public class User : AggregateRoot
{
    public User(string name, string family, string phoneNumber, string email, string password, Gender gender)
    {
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
    }

    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Gender Gender { get; private set; }
    public List<UserAddress> Addresses { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public List<UserWallet> Wallets { get; private set; }

    public void Edit(string name, string family, string phoneNumber, string email, Gender gender)
    {
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }
    public void AddAddress(UserAddress address)
    {
        address.UserId = Id;
        Addresses.Add(address);
    }
    public void EditAddress(UserAddress address)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == address.Id);
        if (oldAddress == null)
            throw new NullOrEmptyDomainDataException("Address Not found");

        Addresses.Remove(oldAddress);
        Addresses.Add(address);
    }
    public void DeleteAddress(Guid addressId)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
        if (oldAddress == null)
            throw new NullOrEmptyDomainDataException("Address Not found");

        Addresses.Remove(oldAddress);
    }

    public void ChargeWallet(UserWallet wallet)
    {
        wallet.UserId = Id;
        Wallets.Add(wallet);
    }

    public void SetRoles(List<UserRole> roles)
    {
        Roles.Clear();
        Roles.AddRange(roles);
    }
}

