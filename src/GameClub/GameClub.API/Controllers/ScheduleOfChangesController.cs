using AutoMapper;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Commands;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Queries;
using GameClub.Domain.DTOs.ScheduleOfChanges;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameClub.API.Controllers;

[Route("api/sochs")]
[ApiController]
public class ScheduleOfChangesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ScheduleOfChangesController(IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var sochs = await _mediator
            .Send(new ScheduleOfChangesGetAllQuery());

        return Ok(sochs);
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

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(ScheduleOfChangesUpdateDto dto)
    {
        var soch = _mapper.Map<ScheduleOfChangesCreateCommand>(dto);

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
