using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Olx.Application.UseCases.Announcements.Queries.GetAllAnnouncement;

namespace Olx.API.Controllers;

[Route("api/announcements")]
[ApiController]
public class AnnouncementsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AnnouncementsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllAnnouncementQuery());

        return Ok(result);
    }
}
