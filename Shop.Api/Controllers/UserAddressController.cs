using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Users.AddAddress;
using Shop.Application.Aggregates.Users.DeleteAddress;
using Shop.Application.Aggregates.Users.EditAddress;
using Shop.Presentation.Facade.Aggregates.Users.UserAddress;

namespace Shop.Api.Controllers;
public class UserAddressController : ApiController
{
	private readonly IUserAddressFacade _addressFacade;

	public UserAddressController(IUserAddressFacade addressFacade)
	{
		_addressFacade = addressFacade;
	}

	[HttpPost]	
	public async Task<ApiResult> AddUserAddress(AddUserAddressCommand command)
	{
		var result = await _addressFacade.AddUserAddress(command);
		return CommandResult(result);
	}

	[HttpPut]
	public async Task<ApiResult> EditUserAddress(EditUserAddressCommand command)
	{
		var result = await _addressFacade.EditUserAddress(command);
		return CommandResult(result);
	}

	[HttpDelete]
	public async Task<ApiResult> DeleteUserAddress(DeleteUserAddressCommand command)
	{
	    var result = await _addressFacade.DeleteUserAddress(command);
		return CommandResult(result);
	}
}


