using Common.Application;
using MediatR;
using Shop.Application.Aggregates.Users.AddAddress;
using Shop.Application.Aggregates.Users.DeleteAddress;
using Shop.Application.Aggregates.Users.EditAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Users.UserAddress;
public class UserAddressFacade : IUserAddressFacade
{
    private readonly IMediator _mediator;

    public UserAddressFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> AddUserAddress(AddUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteUserAddress(DeleteUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditUserAddress(EditUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }
}
