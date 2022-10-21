using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Aggregates.CategoryAgg.Repository;
using Shop.Domain.Aggregates.CommentAgg.Repository;
using Shop.Domain.Aggregates.OrderAgg.Repository;
using Shop.Domain.Aggregates.ProductAgg.Repository;
using Shop.Domain.Aggregates.RoleAgg.Repository;
using Shop.Domain.Aggregates.SellerAgg.Repository;
using Shop.Domain.Aggregates.UserAgg.Repository;
using Shop.Domain.Entities.SiteEntities.Repository;
using Shop.Infrastructure.Persistent.Ef.Aggregates.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.CommentAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.Aggregates.UserAgg;
using Shop.Infrastructure.Persistent.Ef.Entitiess.SiteEntitiess.Banners;
using Shop.Infrastructure.Persistent.Ef.Entitiess.SiteEntitiess.Sliders;

namespace Shop.Infrastructure;
internal class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IBannerRepository, BannerRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
    }
}
