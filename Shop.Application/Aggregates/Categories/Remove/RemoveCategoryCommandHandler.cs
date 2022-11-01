using Common.Application;
using Shop.Domain.Aggregates.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Aggregates.Categories.Remove;

public class RemoveCategoryCommandHandler : IBaseCommandHandler<RemoveCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
    }
    //public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    //{
    //    var result = await _categoryRepository.GetTracking(request.CategoryId);
    //    if (result == null)
    //        return OperationResult.NotFound();

    //    result.DeleteCategory(request.CategoryId, request.ParentId);
    //    await _categoryRepository.Save();
    //    return OperationResult.Success();

    //}
    public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.DeleteCategory(request.CategoryId);
        if (result)
            return OperationResult.Success();

        return OperationResult.Error("امکان حذف وجود ندارد");
    }
}


