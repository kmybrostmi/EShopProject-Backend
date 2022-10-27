using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Aggregates._Utilities;
using Shop.Application.Aggregates.Categories;
using Shop.Application.Aggregates.Products;
using Shop.Application.Aggregates.Sellers;
using Shop.Application.Aggregates.Users;
using Shop.Domain.Aggregates.SellerAgg.Interface;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.Service;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Categories.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Config;
public static class ShopBootstrapper
{
    public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);

        //MediatR 
        services.AddMediatR(typeof(Directories).Assembly);
        services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

        //Domain Services
        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ISellerDomainService, SellerDomainService>();

        //FluentValidator
        services.AddValidatorsFromAssembly(typeof(Directories).Assembly);
    }
}
