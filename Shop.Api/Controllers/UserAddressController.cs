using AutoMapper;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.User;
using Shop.Application.Aggregates.Users.AddAddress;
using Shop.Application.Aggregates.Users.DeleteAddress;
using Shop.Application.Aggregates.Users.EditAddress;
using Shop.Presentation.Facade.Aggregates.Users.UserAddress;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Api.Controllers;
public class UserAddressController : ApiController
{
	private readonly IUserAddressFacade _addressFacade;
	private readonly IMapper _mapper;

	public UserAddressController(IUserAddressFacade addressFacade,IMapper mapper)
	{
		_addressFacade = addressFacade;
		_mapper = mapper;
	}

	[HttpGet("{userAddressId}")]
	public async Task<ApiResult<UserAddressDto?>> GetUserAddressById(Guid userAddressId)
	{
		var result = await _addressFacade.GetUserAddressById(userAddressId);
		return QueryResult(result);
	}

	[HttpGet]
	public async Task<ApiResult<List<UserAddressDto>>> GetUserAddressList()
	{
		var result = await _addressFacade.GetUserAddressList(User.GetUserId());
		return QueryResult(result);
	}

	[HttpPost]	
	public async Task<ApiResult> AddUserAddress(AddUserAddressViewModel viewModel)
	{
		var command = _mapper.Map<AddUserAddressCommand>(viewModel);
		command.UserId = User.GetUserId();
		var result = await _addressFacade.AddUserAddress(command);
		return CommandResult(result);
	}

	[HttpPut]
	public async Task<ApiResult> EditUserAddress(EditUserAddressViewModel viewModel)
	{
        var command = _mapper.Map<EditUserAddressCommand>(viewModel);
        command.UserId = User.GetUserId();
        var result = await _addressFacade.EditUserAddress(command);
		return CommandResult(result);
	}

	[HttpDelete("{addressId}")]
	public async Task<ApiResult> DeleteUserAddress(Guid addressId)
	{
		var userId = new Guid();
	    var result = await _addressFacade.DeleteUserAddress(new DeleteUserAddressCommand(addressId,userId));
		return CommandResult(result);
	}
}


