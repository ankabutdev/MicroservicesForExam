using AutoMapper;
using GameClub.Application.UseCases.HistoryCases.Commands;
using GameClub.Application.UseCases.HistoryCases.Queries;
using GameClub.Domain.DTOs.Histories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameClub.API.Controllers;

[Route("api/histories")]
[ApiController]
public class HistoriesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public HistoriesController(IMapper mapper,
        IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _mediator.Send(new HistoryGetAllQuery()));

    [HttpGet("{searchMessage}")]
    public async Task<IActionResult> HistorySearchAsync(string searchMessage)
    {
        var hisories = await _mediator
            .Send(new HistorySearchQuery() { Message = searchMessage });

        return Ok(hisories);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(HistoryCreateDto dto, CancellationToken token)
    {
        var history = _mapper.Map<HistoryCreateCommand>(dto);

        bool result = await _mediator.Send(history, token);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(HistoryUpdateDto dto, CancellationToken token)
    {
        var history = _mapper.Map<HistoryUpdateCommand>(dto);

        var result = await _mediator.Send(history, token);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new HistoryDeleteCommand() { Id = Id });

        return Ok(result);
    }
}
