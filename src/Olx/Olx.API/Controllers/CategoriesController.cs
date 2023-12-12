using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Olx.Application.UseCases.Categories.Queries.GetAllCategory;

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
}
