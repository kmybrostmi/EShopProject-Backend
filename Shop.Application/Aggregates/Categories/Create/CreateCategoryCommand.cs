using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Categories.Create;
public class CreateCategoryCommand : IBaseCommand
{
    public CreateCategoryCommand(string title, string slug, SeoData seoData)
    {
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }

    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
}
