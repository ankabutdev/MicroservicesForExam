using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Olx.Application.DTOs.Users;
using Olx.Application.UseCases.Users.Commands.CreateUser;
using Olx.Application.UseCases.Users.Commands.DeleteUser;
using Olx.Application.UseCases.Users.Commands.UpdateUser;
using Olx.Application.UseCases.Users.Queries.GetAllUsers;
using Olx.Application.UseCases.Users.Queries.GetUserById;

namespace Olx.API.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllUsersQuery());

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetUserByIdQuery() { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUserDto dto)
    {
        var user = _mapper.Map<CreateUserCommand>(dto);
        var result = await _mediator.Send(user);
        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdateUserDto dto)
    {
        var user = _mapper.Map<UpdateUserCommand>(dto);
        user.Id = Id;
        var result = await _mediator.Send(user);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteUserCommand() { Id = Id });

        return Ok(result);
    }
}
