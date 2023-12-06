using AutoMapper;
using Kindergarten.Application.UseCases.AdminCase.Queries;
using Kindergarten.Application.UseCases.AdminCases.Commands;
using Kindergarten.Domain.Dtos.Admins;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.API.Controllers;

[Route("api/admins")]
[ApiController]
public class AdminsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AdminsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllAdminQuery());
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator.Send(new GetByIdAdminQuery() { Id = Id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAdminDto dto)
    {
        var admin = _mapper.Map<CreateAdminCommand>(dto);

        var result = await _mediator.Send(admin);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateAdminCommand dto)
    {
        var updateAdmin = _mapper.Map<UpdateAdminCommand>(dto);
        var result = await _mediator.Send(updateAdmin);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator.Send(new DeleteAdminCommand() { Id = Id });
        return Ok(result);
    }

}
