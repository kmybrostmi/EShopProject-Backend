using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Facade.Aggregates.Categories;
using Shop.Presentation.Facade.Aggregates.Comments;
using Shop.Presentation.Facade.Aggregates.Orders;
using Shop.Presentation.Facade.Aggregates.Products;
using Shop.Presentation.Facade.Aggregates.Roles;
using Shop.Presentation.Facade.Aggregates.Sellers;
using Shop.Presentation.Facade.Aggregates.Users;
using Shop.Presentation.Facade.Aggregates.Users.UserAddress;
using Shop.Presentation.Facade.Entities.SiteEntities.Banners;
using Shop.Presentation.Facade.Entities.SiteEntities.Sliders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade;
public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<ICommentFacade, CommentFacade>();
        services.AddScoped<IOrderFacade, OrderFacade>();
        services.AddScoped<IProductFacade, ProductFacade>();
        services.AddScoped<IRoleFacade, RoleFacade>();
        services.AddScoped<ISellerFacade, SellerFacade>();
        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<IUserAddressFacade, UserAddressFacade>();
        services.AddScoped<IBannerFacade, BannerFacade>();
        services.AddScoped<ISliderFacade, SliderFacade>();
    }

}
