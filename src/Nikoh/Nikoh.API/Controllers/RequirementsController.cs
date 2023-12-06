using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nikoh.Application.UseCases.RequirementCases.Commands;
using Nikoh.Application.UseCases.RequirementCases.Queris;
using NIkoh.Domain.Dtos.Requirements;

namespace Nikoh.API.Controllers;

[Route("api/requirements")]
[ApiController]
public class RequirementsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public RequirementsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllReqQuery());

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetByIdReqQuery() { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateRequirementDto dto)
    {
        var req = _mapper.Map<CreateReqCmd>(dto);

        var result = await _mediator.Send(req);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateRequirementDto dto)
    {
        var req = _mapper.Map<UpdateReqCmd>(dto);
        var result = await _mediator.Send(req);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteReqCmd() { Id = Id });

        return Ok(result);
    }
}
