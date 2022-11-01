using Shop.Domain.Aggregates.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Products;
public class ProductDomainService : IProductDomainService
{
    private readonly IProductRepository _repository;

    public ProductDomainService(IProductRepository repository)
    {
        _repository = repository;
    }
    public bool IsSlugExist(string slug)
    {
        return _repository.Exists(x => x.Slug == slug);
    }
}
