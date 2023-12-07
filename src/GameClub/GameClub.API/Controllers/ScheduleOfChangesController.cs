using AutoMapper;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Commands;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Queries;
using GameClub.Domain.DTOs.ScheduleOfChanges;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GameClub.API.Controllers;

[Route("api/sochs")]
[ApiController]
public class ScheduleOfChangesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public ScheduleOfChangesController(IMediator mediator,
        IMapper mapper,
        IMemoryCache cache)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllAdmins", out var cachedData))
        {
            var soch = (IEnumerable<ScheduleOfChanges>)cachedData!;
            return Ok(soch);
        }

        var result = await _mediator.Send(new ScheduleOfChangesGetAllQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllScheduleOfChanges", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var soch = await _mediator
            .Send(new ScheduleOfChangesGetByIdQuery() { Id = Id });

        return Ok(soch);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsnyc(ScheduleOfChangesCreateDto dto)
    {
        var soch = _mapper.Map<ScheduleOfChangesCreateCommand>(dto);

        var result = await _mediator.Send(soch);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, ScheduleOfChangesUpdateDto dto)
    {
        var soch = _mapper.Map<ScheduleOfChangesUpdateCommand>(dto);
        soch.Id = Id;
        var result = await _mediator.Send(soch);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(
            new ScheduleOfChangesDeleteCommand()
            {
                Id = Id
            });

        return Ok(result);
    }
}
