using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Aggregates.Categories.Create;
using Shop.Application.Aggregates.Categories.Edit;
using Shop.Presentation.Facade.Aggregates.Categories;
using Shop.Query.Aggregates.Categories.DTOs;

namespace Shop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryFacade _categoryFacade;

    public CategoryController(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetCategories()
    {
        var result = await _categoryFacade.GetCategories(); 
        return Ok(result);
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


