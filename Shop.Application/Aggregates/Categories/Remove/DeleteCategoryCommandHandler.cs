using Common.Application;
using Shop.Domain.Aggregates.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Aggregates.Categories.Remove;

public class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }
    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.GetTracking(request.CategoryId);
        if (result == null)
            return OperationResult.NotFound();

        result.DeleteCategory(request.CategoryId, request.ParentId);
        await _categoryRepository.Save();
        return OperationResult.Success();

    }
}


