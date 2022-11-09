using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModels.Authentication;
using Shop.Application.Aggregates.Users.AddToken;
using Shop.Application.Aggregates.Users.Register;
using Shop.Presentation.Facade.Aggregates.Users;
using Shop.Query.Aggregates.Users.DTOs;
using UAParser;

namespace Shop.Api.Controllers;
public class AuthenticationController : ApiController
{
    private readonly IUserFacade _userFacade;
    private readonly IConfiguration _configuration;

    public AuthenticationController(IUserFacade userFacade, IConfiguration configuration)
    {
        _userFacade = userFacade;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<ApiResult<LoginResultDto>> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
        {
            return new ApiResult<LoginResultDto>()
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
            var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
            return CommandResult(result);
        }
        if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password))
        {
            var result = OperationResult<LoginResultDto>.Error("نام کاربری یا کلمه عبور نادرست است");
            return CommandResult(result);
        }
        if (!user.IsActive)
        {
            var result = OperationResult<LoginResultDto>.Error("حساب کاربری شما غیرفعال است");
            return CommandResult(result);
        }

        var loginResult = await AddTokenAndGenerateJwt(user);

        return CommandResult(loginResult);

        //return new ApiResult<LoginResultDto>()
        //{
        //    Data = await AddTokenAndGenerateJwt(user),
        //    IsSuccess = true,
        //    MetaData = new()
        //};
    }

    [HttpPost("{register}")]
    public async Task<ApiResult> Register(RegisterViewModel registerViewModel)
    {
        var command = new RegisterUserCommand(registerViewModel.PhoneNumber, registerViewModel.Password);
        var result = await _userFacade.RegisterUser(command);
        return CommandResult(result);
    }

    [HttpPost("{RefreshToken}")]
    public async Task<ApiResult> RefreshToken(string refreshToken)
    {
        var result = await _userFacade.GetUserTokenByRefreshToken(refreshToken);
        if (result == null)
            return CommandResult(OperationResult.NotFound());

        if(result.RefreshTokenExpreDate > DateTime.Now)
        {
            return CommandResult(OperationResult.Error("توکن منقضی نشده است"));
        }

        if (result.RefreshTokenExpreDate < DateTime.Now)
        {
            return CommandResult(OperationResult.Error("زمان اعتبار رفرش توکن به پایان رسیده است"));
        }

    }




 

    //private async Task<LoginResultDto?> AddTokenAndGenerateJwt(UserDto user)
    //{
    //    var token = JwtTokenBuilder.BuildToken(user, _configuration);
    //    var refreshToken = Guid.NewGuid().ToString();

    //    var jwtTokenHash = Sha256Hasher.Hash(token);
    //    var refreshTokenHash = Sha256Hasher.Hash(refreshToken);

    //    var uaParser = Parser.GetDefault();
    //    var info = uaParser.Parse(HttpContext.Request.Headers["user-agent"]);
    //    var device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Major} - {info.UA.Family}";

    //    var tokenResult = await _userFacade.AddUserToken(new AddUserTokenCommand(user.Id, jwtTokenHash, refreshTokenHash, DateTime.Now.AddDays(7),
    //                  DateTime.Now.AddDays(8), device));
    //    if (tokenResult.Status != OperationResultStatus.Success)
    //        return null;
    //    return new LoginResultDto()
    //    {
    //        Token = token,
    //        RefreshToken = refreshTokenHash
    //    };
    //}
    private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateJwt(UserDto user)
    {
        var token = JwtTokenBuilder.BuildToken(user, _configuration);
        var refreshToken = Guid.NewGuid().ToString();

        var jwtTokenHash = Sha256Hasher.Hash(token);
        var refreshTokenHash = Sha256Hasher.Hash(refreshToken);

        var uaParser = Parser.GetDefault();
        var info = uaParser.Parse(HttpContext.Request.Headers["user-agent"]);
        var device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Major} - {info.UA.Family}";

        var tokenResult = await _userFacade.AddUserToken(new AddUserTokenCommand(user.Id, jwtTokenHash, refreshTokenHash, DateTime.Now.AddDays(7),
                      DateTime.Now.AddDays(8), device));
        if (tokenResult.Status != OperationResultStatus.Success)
            return OperationResult<LoginResultDto?>.Error();

        return OperationResult<LoginResultDto?>.Success(new LoginResultDto
        {
            RefreshToken = refreshToken,
            Token = token
        });
    }
}

