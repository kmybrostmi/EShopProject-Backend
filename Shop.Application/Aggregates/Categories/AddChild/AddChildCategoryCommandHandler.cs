﻿using Common.Application;
using Shop.Domain.Aggregates.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Aggregates.Categories.AddChild;

public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand,Guid>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public AddChildCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }
    public async Task<OperationResult<Guid>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.GetTracking(request.ParentId);
        if (result == null)
            return OperationResult<Guid>.NotFound();

        result.AddChild(request.Title,request.Slug,request.SeoData,_categoryDomainService);
        await _categoryRepository.Save();
        return OperationResult<Guid>.Success(result.Id);

    }
}




