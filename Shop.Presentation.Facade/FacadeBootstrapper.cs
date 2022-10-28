using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Facade.Aggregates.Categories;
using Shop.Presentation.Facade.Aggregates.Comments;
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
    }

}