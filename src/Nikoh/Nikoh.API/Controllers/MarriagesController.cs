using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nikoh.Application.UseCases.MarriageCases.Commands;
using Nikoh.Application.UseCases.MarriageCases.Queris;
using NIkoh.Domain.Dtos.Marriages;

namespace Nikoh.API.Controllers;

[Route("api/marriages")]
[ApiController]
public class MarriagesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public MarriagesController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllMarriageQuery());

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
