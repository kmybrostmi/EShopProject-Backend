using Shop.Domain.Aggregates.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Categories;
public class CategoryDomainService : ICategoryDomainService
{
    private readonly ICategoryRepository _repository;

    public CategoryDomainService(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public bool IsSlugExist(string slug)
    {
        return _repository.Exists(x=>x.Slug == slug);   
    }
}
