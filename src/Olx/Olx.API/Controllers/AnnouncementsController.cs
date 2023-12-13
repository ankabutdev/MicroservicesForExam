using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Olx.Application.DTOs.Announcements;
using Olx.Application.UseCases.Announcements.Commands.CreateAnnouncement;
using Olx.Application.UseCases.Announcements.Commands.DeleteAnnouncement;
using Olx.Application.UseCases.Announcements.Commands.UpdateAnnouncement;
using Olx.Application.UseCases.Announcements.Queries.GetAllAnnouncement;
using Olx.Application.UseCases.Announcements.Queries.GetByIdAnnouncement;

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

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetByIdAnnouncementQuery() { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAnnouncementDto dto)
    {
        var announcement = _mapper.Map<CreateAnnouncementCommand>(dto);
        var result = await _mediator.Send(announcement);
        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdateAnnouncementDto dto)
    {
        var announcement = _mapper.Map<UpdateAnnouncementCommand>(dto);
        announcement.Id = Id;
        var result = await _mediator.Send(announcement);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteAnnouncementCommand() { Id = Id });

        return Ok(result);
    }
}
