using AutoMapper;
using GameClub.Application.UseCases.PlayerCases.Commands;
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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(PlayerCreateDto dto)
    {
        var player = _mapper.Map<PlayerCreateCommand>(dto);

        var result = await _mediator.Send(player);

        return Ok(result);
    }
}
