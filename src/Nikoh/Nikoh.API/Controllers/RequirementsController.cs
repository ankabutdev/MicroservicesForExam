using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nikoh.Application.UseCases.RequirementCases.Commands;
using Nikoh.Application.UseCases.RequirementCases.Queris;
using NIkoh.Domain.Dtos.Requirements;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.API.Controllers;

[Route("api/requirements")]
[ApiController]
public class RequirementsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public RequirementsController(IMapper mapper, IMediator mediator, IMemoryCache cache)
    {
        _mapper = mapper;
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllAdmins", out var cachedData))
        {
            var reqs = (IEnumerable<Requirement>)cachedData!;
            return Ok(reqs);
        }

        var result = await _mediator.Send(new GetAllReqQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllRequirements", result, cacheEntryOptions);

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

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdateRequirementDto dto)
    {
        var req = _mapper.Map<UpdateReqCmd>(dto);
        req.Id = Id;
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
