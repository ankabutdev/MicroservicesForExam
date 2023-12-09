using AutoMapper;
using GameClub.Application.UseCases.PlayerCases.Commands;
using GameClub.Application.UseCases.PlayerCases.Queries;
using GameClub.Domain.DTOs.Players;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GameClub.API.Controllers;

[Route("api/players")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public PlayersController(IMapper mapper,
        IMediator mediator,
        IMemoryCache cache)
    {
        _mapper = mapper;
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllPlayers", out var cachedData))
        {
            var player = (IEnumerable<Player>)cachedData!;
            return Ok(player);
        }

        var result = await _mediator.Send(new PlayerGetAllQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllPlayers", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("nickname")]
    public async Task<IActionResult> GetByNickNameAsync(string nickname)
    {
        var player = await _mediator
            .Send(new PlayerSearchWithNickNameQuery() { NickName = nickname });

        return Ok(player);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var player = await _mediator
            .Send(new PlayerGetByIdQuery() { Id = Id });

        return Ok(player);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(PlayerCreateDto dto)
    {
        var player = _mapper.Map<PlayerCreateCommand>(dto);

        var result = await _mediator.Send(player);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, PlayerUpdateDto dto)
    {
        var player = _mapper.Map<PlayerUpdateCommand>(dto);
        player.Id = Id;
        var result = await _mediator.Send(player);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(
            new PlayerDeleteCommand()
            {
                Id = Id
            });

        return Ok(result);
    }
}
