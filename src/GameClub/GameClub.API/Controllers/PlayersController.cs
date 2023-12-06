using AutoMapper;
using GameClub.Application.UseCases.PlayerCases.Commands;
using GameClub.Application.UseCases.PlayerCases.Queries;
using GameClub.Domain.DTOs.Players;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameClub.API.Controllers;

[Route("api/players")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PlayersController(IMapper mapper,
        IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var players = await _mediator
            .Send(new PlayerGetAllQuery());

        return Ok(players);
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

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(PlayerUpdateDto dto)
    {
        var player = _mapper.Map<PlayerUpdateCommand>(dto);

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
