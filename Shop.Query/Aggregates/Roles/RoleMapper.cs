using Shop.Domain.CategoryAgg;
using Shop.Domain.RoleAgg;
using Shop.Query.Aggregates.Categories.DTOs;
using Shop.Query.Aggregates.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Roles;
public static class RoleMapper
{
    public static RoleDto? Map(this Role? role)
    {
        if (role == null)
            return null;

        return new()
        {
            CreateDate = role.CreateDate,
            Id = role.Id,
            Permissions = role.Permissions.Select(p => p.Permission).ToList(),
            Title = role.Title
        };
    }

    public static List<RoleDto> Map(this List<Role> roles)
    {
        if (roles == null)
            return null;

        var model = new List<RoleDto>();

        roles.ForEach(role =>
        {
            model.Add(new RoleDto()
            {
                CreateDate = role.CreateDate,
                Id = role.Id,
                Permissions = role.Permissions.Select(p => p.Permission).ToList(),
                Title = role.Title
            });
        });
        return model;
    }
}

