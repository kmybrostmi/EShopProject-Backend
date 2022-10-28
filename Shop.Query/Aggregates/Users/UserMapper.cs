﻿using Microsoft.EntityFrameworkCore;
using Shop.Domain.UserAgg;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Users;
public static class UserMapper
{
    public static UserDto Map(this User user)
    {
        if (user == null)
            return null;

        return new()
        {
            Id = user.Id,
            CreateDate = user.CreateDate,
            Family = user.Family,
            PhoneNumber = user.PhoneNumber,
            AvatarName = user.Avatar,
            Email = user.Email,
            Gender = user.Gender,
            Name = user.Name,
            Password = user.Password,
            IsActive = user.IsActive,
            Roles = user.Roles.Select(s => new UserRoleDto()
            {
                RoleId = s.RoleId,
                RoleTitle = ""
            }).ToList()
        };
    }

    public static UserFilterData MapFilterData(this User user)
    {
        return new UserFilterData()
        {
            Id = user.Id,
            CreateDate = user.CreateDate,
            Family = user.Family,
            PhoneNumber = user.PhoneNumber,
            AvatarName = user.Avatar,
            Email = user.Email,
            Gender = user.Gender,
            Name = user.Name
        };
    }

    public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, ShopDbContext context)
    {
        var roleIds = userDto.Roles.Select(r => r.RoleId);
        var result = await context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
        var roles = new List<UserRoleDto>();
        foreach (var role in result)
        {
            roles.Add(new UserRoleDto()
            {
                RoleId = role.Id,
                RoleTitle = role.Title
            });
        }
        userDto.Roles = roles;
        return userDto;
    }
}

