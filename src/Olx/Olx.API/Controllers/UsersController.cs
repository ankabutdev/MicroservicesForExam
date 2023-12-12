using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Olx.Application.UseCases.Users.Queries.GetAllUsers;

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
}
