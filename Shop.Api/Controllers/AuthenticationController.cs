using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModels.Authentication;
using Shop.Application.Aggregates.Users.Register;
using Shop.Presentation.Facade.Aggregates.Users;

namespace Shop.Api.Controllers;
public class AuthenticationController : ApiController
{
    private readonly IUserFacade _userFacade;
    private readonly IConfiguration _configuration;

    public AuthenticationController(IUserFacade userFacade,IConfiguration configuration)
    {
        _userFacade = userFacade;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<ApiResult<string>> Login(LoginViewModel loginViewModel)
    {
        if(!ModelState.IsValid)
        {
            return new ApiResult<string>()
            {
                Data = null,
                IsSuccess = false,
                MetaData = new()
                {
                    AppStatusCode = AppStatusCode.BadRequest,
                    Message = JoinErrors()
                }
            };
        }
        var user = await _userFacade.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
        if (user == null)
        {
            var result = OperationResult<string>.Error("کاربری با مشخصات وارد شده یافت نشد");
            return CommandResult(result);
        }
        if(Sha256Hasher.IsCompare(user.Password, loginViewModel.Password))
        {
            var result = OperationResult<string>.Error("نام کاربری یا کلمه عبور نادرست است");
            return CommandResult(result);
        }
        if(!user.IsActive)
        {
            var result = OperationResult<string>.Error("حساب کاربری شما غیرفعال است");
            return CommandResult(result);
        }

        var token = JwtTokenBuilder.BuildToken(user, _configuration);
        return new ApiResult<string>()
        {
            Data = token,
            IsSuccess = true,
            MetaData = new()
        };
    }

    [HttpPost("{Register}")]
    public async Task<ApiResult> Register(RegisterViewModel registerViewModel)
    {
        var command = new RegisterUserCommand(registerViewModel.PhoneNumber, registerViewModel.Password);
        var result = await _userFacade.RegisterUser(command);
        return CommandResult(result);
    }
}

