﻿using Common.Application;
using Shop.Application.Aggregates.Users.ChargeWallet;
using Shop.Application.Aggregates.Users.Create;
using Shop.Application.Aggregates.Users.Edit;
using Shop.Application.Aggregates.Users.Register;
using Shop.Query.Aggregates.Users.DTOs;

namespace Shop.Presentation.Facade.Aggregates.Users;
public interface IUserFacade
{
    //Commands
    Task<OperationResult> CreateUser(CreateUserCommand command);
    Task<OperationResult> EditUser(EditUserCommand command);
    Task<OperationResult> RegisterUser(RegisterUserCommand command);
    Task<OperationResult> ChargeUserWallet(ChargeUserWalletCommand command);


    //Queries
    Task<UserDto?> GetUserById(Guid id); 
    Task<UserDto?> GetUserByPhoneNumber(string phoneNumber); 
    Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams); 

}

