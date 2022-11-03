using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Categories.AddChild;
using Shop.Application.Aggregates.Categories.Create;
using Shop.Application.Aggregates.Categories.Edit;
using Shop.Presentation.Facade.Aggregates.Categories;
using Shop.Query.Aggregates.Categories.DTOs;
using System.Net;

namespace Shop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ApiController
{
    private readonly ICategoryFacade _categoryFacade;

    public CategoryController(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    [HttpGet]
    public async Task<ApiResult<List<CategoryDto>>> GetCategories()
    {
        var result = await _categoryFacade.GetCategories();
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<CategoryDto>> GetCategoryById(Guid id)
    {
        var result = await _categoryFacade.GetCategoryById(id);
        return QueryResult(result);
    }

    [HttpGet("getChild/{parentId}")]
    public async Task<ApiResult<List<ChildCategoryDto>>> GetCategoryByParentId(Guid parentId)
    {
        var result = await _categoryFacade.GetCategoriesByParentId(parentId);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult<Guid>> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _categoryFacade.CreateCategory(command);
        var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, HttpStatusCode.Created, url);
    }

    [HttpPost("AddChild")]
    public async Task<ApiResult<Guid>> AddChildCategory(AddChildCategoryCommand command, Guid parentId)
    {
        var parentid = await _categoryFacade.GetCategoriesByParentId(parentId);
        if(parentid == null)
        {
            var child = await _categoryFacade.AddChildCategory(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = child.Data }, Request.Scheme);
            return CommandResult(child, HttpStatusCode.Created, url);
        }
        var childs = await _categoryFacade.AddChildCategory(command);
        var urls = Url.Action("GetCategoryById", "Category", new { id = childs.Data }, Request.Scheme);
        return CommandResult(childs, HttpStatusCode.Created, urls);
    }

    [HttpPut]
    public async Task<ApiResult> EditCategory(EditCategoryCommand command)
    {
        var result = await _categoryFacade.EditCategory(command);
        return CommandResult(result);
    }

    [HttpDelete("{categoryId}")]
    public async Task<ApiResult> RemoveCategory(Guid categoryId)
    {
        var result = await _categoryFacade.RemoveCategory(categoryId);
        return CommandResult(result);
    }
}




