using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Aggregates.Users.EditAddress;
public class EditUserAddressCommand:IBaseCommand
{
    public EditUserAddressCommand(Guid addressId, Guid userId, string shire, string city, string postalCode, 
        string postalAddress, PhoneNumber phoneNumber, string name, string family, NationalCode nationalCode)
    {
        AddressId = addressId;
        UserId = userId;
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }

    public Guid AddressId { get; internal set; }
    public Guid UserId { get; internal set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public NationalCode NationalCode { get; private set; }
}
