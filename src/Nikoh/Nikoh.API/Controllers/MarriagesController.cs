using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nikoh.Application.UseCases.MarriageCases.Commands;
using Nikoh.Application.UseCases.MarriageCases.Queris;
using NIkoh.Domain.Dtos.Marriages;
using NIkoh.Domain.Entities.Marriages;

namespace Nikoh.API.Controllers;

[Route("api/marriages")]
[ApiController]
public class MarriagesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public MarriagesController(IMapper mapper, IMediator mediator, IMemoryCache cache)
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
            var marriages = (IEnumerable<Marriage>)cachedData!;
            return Ok(marriages);
        }

        var result = await _mediator.Send(new GetAllMarriageQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllMarriages", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetByIdMarriageQuery() { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateMarriageDto dto)
    {
        var marriage = _mapper.Map<CreateMarriageCmd>(dto);

        var result = await _mediator.Send(marriage);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdateMarriageDto dto)
    {
        var marriage = _mapper.Map<UpdateMarriageCmd>(dto);
        marriage.Id = Id;
        var result = await _mediator.Send(marriage);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteMarriageCmd() { Id = Id });

        return Ok(result);
    }

}
