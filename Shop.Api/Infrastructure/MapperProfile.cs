using AutoMapper;
using Shop.Api.ViewModels.User;
using Shop.Application.Aggregates.Users.AddAddress;
using Shop.Application.Aggregates.Users.EditAddress;

namespace Shop.Api.Infrastructure;
public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<AddUserAddressCommand,AddUserAddressViewModel>().ReverseMap();
		CreateMap<EditUserAddressCommand,EditUserAddressViewModel>().ReverseMap();
	}
}
