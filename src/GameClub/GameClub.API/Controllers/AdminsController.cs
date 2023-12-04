using AutoMapper;
using GameClub.Application.UseCases.AdminCases.Commands;
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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(AdminCreateDto dto)
    {
        var adminCommand = _mapper.Map<CreateAdminCommand>(dto);
        await _mediator.Send(adminCommand);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(AdminUpdateDto dto)
    {
        var updateAdmin = _mapper.Map<UpdateAdminCommand>(dto);
        await Console.Out.WriteLineAsync(updateAdmin.Password);
        await _mediator.Send(updateAdmin);
        return Ok();
    }
}
