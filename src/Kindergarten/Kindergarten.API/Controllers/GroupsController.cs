using AutoMapper;
using Kindergarten.Application.UseCases.GroupCase.Commands;
using Kindergarten.Application.UseCases.GroupCase.Queries;
using Kindergarten.Domain.Dtos.Groups;
using Kindergarten.Domain.Entities.Groups;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Kindergarten.API.Controllers;

[Route("api/groups")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public GroupsController(IMapper mapper, IMediator mediator, IMemoryCache cache)
    {
        _mapper = mapper;
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllGroups", out var cachedData))
        {
            var group = (IEnumerable<Group>)cachedData!;
            return Ok(group);
        }

        var result = await _mediator.Send(new GetAllGroupQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllGroups", result, cacheEntryOptions);

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

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, GroupUpdateDto dto)
    {
        var group = _mapper.Map<UpdateGroupCmd>(dto);
        group.Id = Id;
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
