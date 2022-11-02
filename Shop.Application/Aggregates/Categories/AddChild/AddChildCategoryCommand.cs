using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Categories.AddChild;
public class AddChildCategoryCommand:IBaseCommand
{
    public AddChildCategoryCommand(Guid parentId, string title, string slug, SeoData seoData)
    {
        ParentId = parentId;
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }

    public Guid ParentId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
}




