using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Users.ChargeWallet;
using Shop.Application.Aggregates.Users.Create;
using Shop.Application.Aggregates.Users.Edit;
using Shop.Application.Aggregates.Users.Register;
using Shop.Presentation.Facade.Aggregates.Users;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Api.Controllers;
public class UserController : ApiController
{
	private readonly IUserFacade _userFacade;

	public UserController(IUserFacade userFacade)
	{
		_userFacade = userFacade;
	}

    //[HttpGet("{userId}")]
    //public async Task<ApiResult<UserDto?>> GetUserById(Guid userId)
    //{
    //	var result = await _userFacade.GetUserById(userId);
    //	return QueryResult(result);
    //}

    //[HttpGet("{phoneNumber}")]
    //public async Task<ApiResult<UserDto?>> GetUserByPhoneNumber(string phoneNumber)
    //{
    //	var result = await _userFacade.GetUserByPhoneNumber(phoneNumber);
    //	return QueryResult(result);
    //}

    //[HttpGet]
    //public async Task<ApiResult<UserFilterResult>> GetUserByFilter([FromQuery] UserFilterParams filterParams)
    //{
    //    var result = await _userFacade.GetUserByFilter(filterParams);
    //    return QueryResult(result);
    //}

    [HttpPost]
    public async Task<ApiResult> CreateUser(CreateUserCommand command)
    {
        var result = await _userFacade.CreateUser(command);
        return CommandResult(result);
    }

    ////[HttpPost]
    ////public async Task<ApiResult> RegisterUser(RegisterUserCommand command)
    ////{
    ////    var result = await _userFacade.RegisterUser(command);
    ////    return CommandResult(result);
    ////}

    ////[HttpPut]
    ////public async Task<ApiResult> EditUser(EditUserCommand command)
    ////{
    ////    var result = await _userFacade.EditUser(command);
    ////    return CommandResult(result);
    ////}

    ////[HttpPut]
    ////public async Task<ApiResult> ChargeWallet(ChargeUserWalletCommand command)
    ////{
    ////    var result = await _userFacade.ChargeUserWallet(command);
    ////    return CommandResult(result);
    ////}
}


