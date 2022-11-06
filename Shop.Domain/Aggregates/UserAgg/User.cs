using Common.Domain;
using Common.Domain.ValueObjects;
using Shop.Domain.OrderAgg;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg;
public class User : AggregateRoot
{
    private User()
    {

    }
    public User(string name, string family, string phoneNumber, string email, string password, 
        Gender gender, IUserDomainService userDomain)
    {
        Guard(phoneNumber, email, userDomain);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        IsActive = true;    
        Gender = gender;
        Avatar = "Avatar.png";
    }

    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Avatar { get; private set; }
    public Gender Gender { get; private set; }
    public bool IsActive { get; set; }
    public List<UserAddress> Addresses { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public List<UserWallet> Wallets { get; private set; }


    public void SetAvatar(string imageName)
    {
        if (string.IsNullOrWhiteSpace(imageName))
            imageName = "avatar.png";

        Avatar = imageName;
    }

    public void Edit(string name, string family, string phoneNumber, string email, 
        Gender gender, IUserDomainService userDomain)
    {
        Guard(phoneNumber, email, userDomain);
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
    public void EditAddress(UserAddress address, Guid addressId)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
        if (oldAddress == null)
            throw new NullOrEmptyDomainDataException("Address Not found");

        //Addresses.Remove(oldAddress);
        //Addresses.Add(address);
        oldAddress.Edit(address.Shire, address.City, address.PostalCode, address.PostalAddress, address.PhoneNumber,
                address.Name, address.Family, address.NationalCode);
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
        Roles.ForEach(r => r.UserId = Id);
        Roles.Clear();
        Roles.AddRange(roles);
    }

    public static User RegisterUser(string phoneNumber, string password, IUserDomainService userDomain)
    {
        return new User(string.Empty, string.Empty, phoneNumber,null, password, Gender.Male, userDomain);
    }
    public void Guard(string phoneNumber, string email, IUserDomainService userDomain)
    {
        if (phoneNumber == null)
        {
            throw new NullOrEmptyDomainDataException();
        }

        if (!string.IsNullOrWhiteSpace(email))
            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException(" ایمیل نامعتبر است");

        if (phoneNumber != PhoneNumber)
            if (userDomain.IsPhoneNumberExist(phoneNumber))
                throw new InvalidDomainDataException("شماره موبایل تکراری است");

        //if(!string.IsNullOrWhiteSpace(email))   
         if (email != Email)
            if (userDomain.IsEmailExist(email))
                throw new InvalidDomainDataException("ایمیل تکراری است");
    }
}

