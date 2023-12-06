using AutoMapper;
using Kindergarten.Application.UseCases.GroupCase.Commands;
using Kindergarten.Application.UseCases.GroupCase.Queries;
using Kindergarten.Domain.Dtos.Groups;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.API.Controllers;

[Route("api/groups")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GroupsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllGroupQuery());

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetByIdGroupQuery() { Id = Id });
        return Ok(result);
    }

    [HttpGet("groupName")]
    public async Task<IActionResult> SearchByGroupNameAsnyc(string groupName)
    {
        var result = await _mediator
            .Send(new SearchByGroupNameQuery() { Name = groupName });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsnyc(GroupCreateDto dto)
    {
        var group = _mapper.Map<CreateGroupCmd>(dto);

        var result = await _mediator.Send(group);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(GroupUpdateDto dto)
    {
        var group = _mapper.Map<UpdateGroupCmd>(dto);

        var result = await _mediator.Send(group);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteGroupCmd() { Id = Id });

        return Ok(result);
    }
}
