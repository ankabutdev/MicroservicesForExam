using AutoMapper;
using GameClub.Application.UseCases.ComputerCases.Commands;
using GameClub.Application.UseCases.ComputerCases.Queries;
using GameClub.Domain.DTOs.Computers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameClub.API.Controllers;

[Route("api/computers")]
[ApiController]
public class ComputersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ComputersController(IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var computers = await _mediator
            .Send(new ComputerGetAllQuery());

        return Ok(computers);
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
