﻿namespace Shop.Api.Infrastructure;
public static class DependencyRegister
{
    public static void RegisterApiDependency(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile).Assembly);

        services.AddCors(options =>
        {
            options.AddPolicy(name: "EShopApi",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }
}