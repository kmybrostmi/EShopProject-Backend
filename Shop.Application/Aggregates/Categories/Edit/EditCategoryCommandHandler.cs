using Common.Application;
using Shop.Domain.Aggregates.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Aggregates.Categories.Edit;

public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public EditCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }
    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.GetTracking(request.ProductId);
        if (result == null)
            return OperationResult.NotFound();

        result.Edit(result.Title,result.Slug,result.SeoData,_categoryDomainService);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}

