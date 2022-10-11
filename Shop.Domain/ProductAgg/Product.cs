﻿using Common.Domain;
using Common.Domain.ValueObjects;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg;
public class Product : AggregateRoot
{
    private Product()
    {
    }

    public Product(string title, string imageName, string description, Guid categoryId, Guid subCategoryId, 
        Guid? secondarySubCategoryId, string slug, SeoData seoData)
    {
        Title = title;
        ImageName = imageName;
        Description = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        Slug = slug;
        SeoData = seoData;
    }
    
    public string Title { get; private set; }
    public string ImageName { get; private set; }
    public string Description { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid SubCategoryId { get; private set; }
    public Guid? SecondarySubCategoryId { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public List<ProductSpecification> Specifications { get; private set; }


    public void Edit(string title, string description, Guid categoryId,
            Guid subCategoryId, Guid? secondarySubCategoryId, string slug, SeoData seoData)
    {
        Title = title;
        Description = description;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        Slug = slug;
        SeoData = seoData;
    }

    public void SetImage(ProductImage image)
    {
        image.ProductId = Id;
        Images.Add(image);
    }

    public string RemoveImage(Guid id)
    {
        var image = Images.FirstOrDefault(x => x.Id == id);
        if (image == null)
            throw new NullOrEmptyDomainDataException("عکس یافت نشد");

        Images.Remove(image);
        return image.ImageName;
    }

    public void SetSpecification(List<ProductSpecification> specifications)
    {
        Specifications.ForEach(s => s.ProductId = Id);
        Specifications = specifications;
    }
}



