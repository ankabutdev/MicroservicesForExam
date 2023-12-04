using GameClub.Application.UseCases.Admin.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameClub.API.Controllers;

[Route("api/admins")]
[ApiController]
public class AdminsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAdminCommand adminCommand)
    {
        var result = _mediator.Send(adminCommand);
        return Ok();
    }
}
