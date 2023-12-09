using AutoMapper;
using GameClub.Application.UseCases.ComputerCases.Commands;
using GameClub.Application.UseCases.ComputerCases.Queries;
using GameClub.Domain.DTOs.Computers;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GameClub.API.Controllers;

[Route("api/computers")]
[ApiController]
public class ComputersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public ComputersController(IMediator mediator,
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
        if (_cache.TryGetValue("AllComputers", out var cachedData))
        {
            IEnumerable<Computer>? computer = (IEnumerable<Computer>)cachedData;
            return Ok(computer);
        }

        var result = await _mediator.Send(new ComputerGetAllQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllComputers", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var computer = await _mediator
            .Send(new ComputerGetByIdQuery() { Id = Id });

        return Ok(computer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsnyc(ComputerCreateDto dto)
    {
        var computer = _mapper.Map<ComputerCreateCommand>(dto);

        var result = await _mediator.Send(computer);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, ComputerUpdateDto dto)
    {
        var computer = _mapper.Map<ComputerUpdateCommand>(dto);
        computer.Id = Id;
        var result = await _mediator.Send(computer);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(
            new ComputerDeleteCommand()
            {
                Id = Id
            });

        return Ok(result);
    }
}
