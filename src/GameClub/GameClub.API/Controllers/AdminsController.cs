using AutoMapper;
using GameClub.Application.UseCases.AdminCases.Commands;
using GameClub.Application.UseCases.AdminCases.Queries;
using GameClub.Domain.DTOs.Admins;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameClub.API.Controllers;

[Route("api/admins")]
[ApiController]
public class AdminsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AdminsController(IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator.Send(new AdminGetAllQuery());
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator.Send(new AdminGetByIdQuery() { Id = Id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(AdminCreateDto dto)
    {
        var adminCommand = _mapper.Map<CreateAdminCommand>(dto);
        var result = await _mediator.Send(adminCommand);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(AdminUpdateDto dto)
    {
        var updateAdmin = _mapper.Map<UpdateAdminCommand>(dto);
        var result = await _mediator.Send(updateAdmin);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator.Send(new AdminDeleteCommand() { Id = Id });
        return Ok(result);
    }
}
