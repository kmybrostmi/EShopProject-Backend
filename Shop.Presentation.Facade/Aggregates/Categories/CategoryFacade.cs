using Common.Application;
using MediatR;
using Shop.Application.Aggregates.Categories.AddChild;
using Shop.Application.Aggregates.Categories.Create;
using Shop.Application.Aggregates.Categories.Edit;
using Shop.Application.Aggregates.Categories.Remove;
using Shop.Query.Aggregates.Categories.DTOs;
using Shop.Query.Aggregates.Categories.GetById;
using Shop.Query.Aggregates.Categories.GetByParentId;
using Shop.Query.Aggregates.Categories.GetList;

namespace Shop.Presentation.Facade.Aggregates.Categories;

internal class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;

    public CategoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult<Guid>> AddChild(AddChildCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<Guid>> Create(CreateCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> Remove(Guid categoryId, Guid parentId)
    {
        return await _mediator.Send(new DeleteCategoryCommand(categoryId, parentId));   
    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _mediator.Send(new GetCategoryListQuery());
    }

    public async Task<List<ChildCategoryDto>> GetCategoriesByParentId(Guid parentId)
    {
        return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));
    }

    public async Task<CategoryDto> GetCategoryById(Guid id)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(id));
    }
}
