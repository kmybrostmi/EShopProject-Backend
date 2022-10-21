using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Users.DeleteAddress;
public class DeleteUserAddressCommand:IBaseCommand
{
    public DeleteUserAddressCommand(Guid addressId, Guid userId)
    {
        AddressId = addressId;
        UserId = userId;
    }

    public Guid AddressId { get; private set; }
    public Guid UserId { get; private set; }
}



