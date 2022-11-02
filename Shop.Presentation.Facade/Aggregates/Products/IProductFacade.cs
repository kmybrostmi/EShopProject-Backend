using Common.Application;
using Shop.Application.Aggregates.Products.AddImage;
using Shop.Application.Aggregates.Products.Create;
using Shop.Application.Aggregates.Products.Edit;
using Shop.Application.Aggregates.Products.RemoveImage;
using Shop.Query.Aggregates.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Aggregates.Products;
public interface IProductFacade
{
    //Commands
    Task<OperationResult> CreateProduct(CreateProductCommand command);
    Task<OperationResult> EditProduct(EditProductCommand command);
    Task<OperationResult> AddProductImage(AddProductImageCommand command);
    Task<OperationResult> RemoveProductImage(RemoveProductImageCommand command);
    
    //Queries
    Task<ProductDto?> GetProductById(Guid id);   
    Task<ProductDto?> GetProductBySlug(string slug);   
    Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams);   
}
