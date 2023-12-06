using AutoMapper;
using Kindergarten.Application.UseCases.ParentCase.Commands;
using Kindergarten.Application.UseCases.ParentCase.Queries;
using Kindergarten.Domain.Dtos.Parents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.API.Controllers;

[Route("api/parents")]
[ApiController]
public class ParentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ParentsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllParentQuery());

        return Ok(result);
    }

    [HttpGet("phoneNumber")]
    public async Task<IActionResult> SearchByPhoneNumberAsync(string phoneNumber)
    {
        var result = await _mediator
            .Send(new SearchParentByPhoneNumberQuery()
            { PhoneNumber = phoneNumber });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateParentDto dto)
    {
        var parent = _mapper.Map<CreateParentCmd>(dto);

        var result = await _mediator.Send(parent);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateParentDto dto)
    {
        var parent = _mapper.Map<UpdateParentCmd>(dto);

        var result = await _mediator.Send(parent);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteParentCmd() { Id = Id });

        return Ok(result);
    }
}
