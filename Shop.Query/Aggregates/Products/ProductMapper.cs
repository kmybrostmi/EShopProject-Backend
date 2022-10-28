using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure;
using Shop.Query.Aggregates.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Aggregates.Products;
public static class ProductMapper
{
    public static ProductDto? Map(this Product? product)
    {
        if (product == null)
            return null;

        return new ProductDto()
        {
            Id = product.Id,
            CreateDate = product.CreateDate,
            Description = product.Description,
            ImageName = product.ImageName,
            Slug = product.Slug,
            Title = product.Title,
            SeoData = product.SeoData,
            Specifications = product.Specifications.Select(s => new ProductSpecificationDto()
            {
                Value = s.Value,
                Key = s.Key
            }).ToList(),
            Images = product.Images.Select(s => new ProductImageDto()
            {
                Id = s.Id,
                CreateDate = s.CreateDate,
                ImageName = s.ImageName,
                ProductId = s.ProductId,
                Sequence = s.Sequence
            }).ToList(),
            Category = new()
            {
                Id = product.CategoryId
            },
            SubCategory = new()
            {
                Id = product.SubCategoryId
            },
            SecondarySubCategory = product.SecondarySubCategoryId != null ? new()
            {
                Id = (Guid)product.SecondarySubCategoryId
            } : null,
        };
    }

    public static ProductFilterData MapListData(this Product product)
    {
        return new ProductFilterData()
        {
            Id = product.Id,
            CreateDate = product.CreateDate,
            ImageName = product.ImageName,
            Slug = product.Slug,
            Title = product.Title
        };
    }

    public static async Task SetCategories(this ProductDto product, ShopDbContext context)
    {
        var categories = await context.Categories
            .Where(r => r.Id == product.Category.Id || r.Id == product.SubCategory.Id)
            .Select(s => new ProductCategoryDto()
            {
                Id = s.Id,
                Slug = s.Slug,
                ParentId = s.ParentId,
                SeoData = s.SeoData,
                Title = s.Title
            }).ToListAsync();

        if (product.SecondarySubCategory != null)
        {
            var secondarySubCategory = await context.Categories
                .Where(f => f.Id == product.SecondarySubCategory.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    Slug = s.Slug,
                    ParentId = s.ParentId,
                    SeoData = s.SeoData,
                    Title = s.Title
                })
                .FirstOrDefaultAsync();

            if (secondarySubCategory != null)
                product.SecondarySubCategory = secondarySubCategory;
        }
        product.Category = categories.First(r => r.Id == product.Category.Id);
        product.SubCategory = categories.First(r => r.Id == product.SubCategory.Id);
    }
}
