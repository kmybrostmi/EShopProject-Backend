using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Categories.AddChild;
using Shop.Application.Aggregates.Categories.Create;
using Shop.Application.Aggregates.Categories.Edit;
using Shop.Presentation.Facade.Aggregates.Categories;
using Shop.Query.Aggregates.Categories.DTOs;

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
        return new ApiResult<List<CategoryDto>>()
        {
            Data = result,
            MetaData = new MetaData()
            {
                AppStatusCode = AppStatusCode.Success,
                Message = "عملیات با موفقیت انجام  شد"
            },
            IsSuccess = true
        };
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
    {
        var result = await _categoryFacade.GetCategoryById(id);
        return Ok(result);  
    }

    [HttpGet("getChild/{parentId}")]
    public async Task<ActionResult<List<ChildCategoryDto>>> GetCategoryByParentId(Guid parentId)
    {
        var result = await _categoryFacade.GetCategoriesByParentId(parentId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _categoryFacade.CreateCategory(command);
        if(result.Status == Common.Application.OperationResultStatus.Success)
            return Ok();  
        else
            return BadRequest(result.Message);
    }

    [HttpPost("AddChild")]
    public async Task<IActionResult> AddChildCategory(AddChildCategoryCommand command, Guid parentId)
    {
        var parentid = await _categoryFacade.GetCategoriesByParentId(parentId);
        if(parentid == null)
        {
            var child = await _categoryFacade.AddChildCategory(command);
            if(child.Status == Common.Application.OperationResultStatus.Success)
            return Ok();
            else return BadRequest(child.Message);  
        }
        var childs = await _categoryFacade.AddChildCategory(command);
        if (childs.Status == Common.Application.OperationResultStatus.Success)
            return Ok();
        else return BadRequest(childs.Message);

    }

    [HttpPut]
    public async Task<IActionResult> EditCategory(EditCategoryCommand command)
    {
        var result = await _categoryFacade.EditCategory(command);
        if (result.Status == Common.Application.OperationResultStatus.Success)
            return Ok();
        else
            return BadRequest(result.Message);
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> RemoveCategory(Guid categoryId)
    {
        var result = await _categoryFacade.RemoveCategory(categoryId);
        if (result.Status == Common.Application.OperationResultStatus.Success)
            return Ok();
        else
            return BadRequest(result.Message);
    }
}



