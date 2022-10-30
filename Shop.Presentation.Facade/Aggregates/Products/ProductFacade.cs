using Common.Application;
using MediatR;
using Shop.Application.Aggregates.Products.AddImage;
using Shop.Application.Aggregates.Products.Create;
using Shop.Application.Aggregates.Products.Edit;
using Shop.Application.Aggregates.Products.RemoveImage;
using Shop.Query.Aggregates.Products.DTOs;
using Shop.Query.Aggregates.Products.GetByFilter;
using Shop.Query.Aggregates.Products.GetById;
using Shop.Query.Aggregates.Products.GetBySlug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Products;
public class ProductFacade : IProductFacade
{
    private readonly IMediator _mediator;

    public ProductFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public Task<OperationResult> AddProductImage(AddProductImageCommand command)
    {
       return _mediator.Send(command);
    }

    public Task<OperationResult<Guid>> CreateProduct(CreateProductCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<OperationResult> EditProduct(EditProductCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams)
    {
        return _mediator.Send(new GetProductByFilterQuery(filterParams));
    }

    public Task<ProductDto?> GetProductById(Guid id)
    {
        return _mediator.Send(new GetProductByIdQuery(id));
    }

    public Task<ProductDto?> GetProductBySlug(string slug)
    {
        return _mediator.Send(new GetProductBySlugQuery(slug));
    }

    public Task<OperationResult> RemoveProductImage(RemoveProductImageCommand command)
    {
        return _mediator.Send(command);
    }
}
