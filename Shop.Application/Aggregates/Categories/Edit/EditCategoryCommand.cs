using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Categories.Edit;
public class EditCategoryCommand:IBaseCommand
{
    public EditCategoryCommand(Guid productId, string title, string slug, SeoData seoData)
    {
        ProductId = productId;
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }

    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
}

