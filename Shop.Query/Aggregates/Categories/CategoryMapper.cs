using Shop.Domain.CategoryAgg;
using Shop.Query.Aggregates.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Categories;
internal static class CategoryMapper
{
    public static CategoryDto Map(this Category? category)
    {
        if (category == null)
            return null;

        return new CategoryDto()
        {
            Title = category.Title,
            Slug = category.Slug,
            Id = category.Id,
            SeoData = category.SeoData,
            CreateDate = category.CreateDate,
            Childs = category.Childs.MapChildren()
        };
    }

    public static List<ChildCategoryDto> MapChildren(this List<Category> children)
    {
        var model = new List<ChildCategoryDto>();

        children.ForEach(c =>
        {
            model.Add(new ChildCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreateDate = c.CreateDate,
                ParentId = (Guid)c.ParentId,
                Childs = c.Childs.MapSecondaryChild()

            });
        });
        return model;
    }

    private static List<SecondaryChildCategoryDto> MapSecondaryChild(this List<Category> children)
    {
        var model = new List<SecondaryChildCategoryDto>();
        children.ForEach(c =>
        {
            model.Add(new SecondaryChildCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreateDate = c.CreateDate,
                ParentId = (Guid)c.ParentId,
            });
        });
        return model;
    }

}
