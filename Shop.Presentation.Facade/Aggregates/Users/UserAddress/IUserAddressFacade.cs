using Common.Application;
using Shop.Application.Aggregates.Users.AddAddress;
using Shop.Application.Aggregates.Users.DeleteAddress;
using Shop.Application.Aggregates.Users.EditAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Users.UserAddress;
public interface IUserAddressFacade
{
    //Commands
    Task<OperationResult> AddUserAddress(AddUserAddressCommand command);
    Task<OperationResult> EditUserAddress(EditUserAddressCommand command);
    Task<OperationResult> DeleteUserAddress(DeleteUserAddressCommand command);


    //Queries
}
