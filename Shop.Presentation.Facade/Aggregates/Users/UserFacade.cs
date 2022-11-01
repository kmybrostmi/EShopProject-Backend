using Common.Application;
using MediatR;
using Shop.Application.Aggregates.Users.ChargeWallet;
using Shop.Application.Aggregates.Users.Create;
using Shop.Application.Aggregates.Users.Edit;
using Shop.Application.Aggregates.Users.Register;
using Shop.Query.Aggregates.Users.DTOs;
using Shop.Query.Aggregates.Users.GetByFilter;
using Shop.Query.Aggregates.Users.GetById;
using Shop.Query.Aggregates.Users.GetByPhoneNumber;

namespace Shop.Presentation.Facade.Aggregates.Users;
public class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;

    public UserFacade(IMediator mediator)
    {
       _mediator = mediator;
    }
    public async Task<OperationResult> ChargeUserWallet(ChargeUserWalletCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> CreateUser(CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditUser(EditUserCommand command)
    {
        return await _mediator.Send(command);   
    }

    public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
    {
        return await _mediator.Send(new GetUserByFilterQuery(filterParams));
    }

    public async Task<UserDto> GetUserById(Guid id)
    {
        return await _mediator.Send(new GetUserByIdQuery(id));
    }

    public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }
}
