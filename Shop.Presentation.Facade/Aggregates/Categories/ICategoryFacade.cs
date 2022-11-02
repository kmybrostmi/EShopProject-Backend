using Common.Application;
using Shop.Application.Aggregates.Categories.AddChild;
using Shop.Application.Aggregates.Categories.Create;
using Shop.Application.Aggregates.Categories.Edit;
using Shop.Application.Aggregates.Categories.Remove;
using Shop.Query.Aggregates.Categories.DTOs;

namespace Shop.Presentation.Facade.Aggregates.Categories;
public interface ICategoryFacade
{
    //Commands
    Task<OperationResult> AddChildCategory(AddChildCategoryCommand command);
    Task<OperationResult> CreateCategory(CreateCategoryCommand command);
    Task<OperationResult> RemoveCategory(Guid categoryId);
    Task<OperationResult> EditCategory(EditCategoryCommand command);

    //Queries
    Task<CategoryDto> GetCategoryById(Guid id);
    Task<List<CategoryDto>> GetCategories();
    Task<List<ChildCategoryDto>> GetCategoriesByParentId(Guid parentId);
}




