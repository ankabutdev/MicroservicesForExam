using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Olx.Application.DTOs.Categories;
using Olx.Application.UseCases.Categories.Commands.CreateCategory;
using Olx.Application.UseCases.Categories.Commands.DeleteCategory;
using Olx.Application.UseCases.Categories.Commands.UpdateCategory;
using Olx.Application.UseCases.Categories.Queries.GetAllCategory;
using Olx.Application.UseCases.Categories.Queries.GetCategoryById;

namespace Olx.API.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllCategoryQuery());

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetCategoryByIdQuery() { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCategoryDto dto)
    {
        var category = _mapper.Map<CreateCategoryCommand>(dto);
        var result = await _mediator.Send(category);
        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdateCategoryDto dto)
    {
        var category = _mapper.Map<UpdateCategoryCommand>(dto);
        category.Id = Id;
        var result = await _mediator.Send(category);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteCategoryCommand() { Id = Id });

        return Ok(result);
    }
}
