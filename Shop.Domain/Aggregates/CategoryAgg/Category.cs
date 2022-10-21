using Common.Domain;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAgg;
public class Category : AggregateRoot
{
    private Category()
    {
        Childs = new List<Category>();
    }

    public Category(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        Guard(title, slug, service);
        Title = title;
        Slug = slug.ToSlug();
        SeoData = seoData;
        Childs = new List<Category>();
    }

    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public Guid? ParentId { get; private set; }
    public List<Category> Childs { get; private set; }

    public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        Guard(title, slug, service);
        Title = title;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }

    public void Guard(string title, string slug, ICategoryDomainService service)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

        if (slug != Slug)
            if (service.IsSlugExist(slug))
                throw new SlugIsDuplicateException();
    }

    public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService service)
    {
        Childs.Add(new Category(title, slug, seoData, service)
        {
            ParentId = Id
        });
    }

    public void DeleteCategory(Guid categoryId,Guid parentId)
    {
        var deleteCategory = Childs.FirstOrDefault(c => c.Id == categoryId);
        if (deleteCategory != null && parentId != null)
            Childs.Remove(deleteCategory);            
    }
}

