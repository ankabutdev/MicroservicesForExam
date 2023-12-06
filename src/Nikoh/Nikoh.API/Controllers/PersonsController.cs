using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nikoh.Application.UseCases.PersonCases.Commands;
using Nikoh.Application.UseCases.PersonCases.Queris;
using NIkoh.Domain.Dtos.Persons;

namespace Nikoh.API.Controllers;

[Route("api/persons")]
[ApiController]
public class PersonsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PersonsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllPersonQuery());

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetByIdPersonQuery() { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatePersonDto dto)
    {
        var person = _mapper.Map<CreatePersonCmd>(dto);

        var result = await _mediator.Send(person);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdatePersonDto dto)
    {
        var person = _mapper.Map<UpdatePersonCmd>(dto);
        var result = await _mediator.Send(person);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeletePersonCmd() { Id = Id });

        return Ok(result);
    }
}
