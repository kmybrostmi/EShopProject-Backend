﻿using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shop.Presentation.Facade.Aggregates.Users;

namespace Shop.Api.Infrastructure.JwtUtil;
public class CustomJwtValidation
{
    private readonly IUserFacade _userFacade;

    public CustomJwtValidation(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }
    public async Task Validate(TokenValidatedContext context)
    {
        var userId = context.Principal.GetUserId();
        var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var token = _userFacade.GetUserTokenByJwtToken(jwtToken);
        if (token == null)
        {
            context.Fail("Token not found");
            return;
        }
        var user = await _userFacade.GetUserById(userId);
        if (user == null || user.IsActive == false)
        {
            context.Fail("User not active");
            return;
        }
    }
}


