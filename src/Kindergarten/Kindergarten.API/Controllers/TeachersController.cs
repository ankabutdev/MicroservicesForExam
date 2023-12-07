using AutoMapper;
using Kindergarten.Application.UseCases.TeacherCase.Commands;
using Kindergarten.Application.UseCases.TeacherCase.Queries;
using Kindergarten.Domain.Dtos.Teachers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.API.Controllers;

[Route("api/teachers")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public TeachersController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllTeacherQuery());

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetByIdTeacherQuery() { Id = Id });

        return Ok(result);
    }

    [HttpGet("fullName")]
    public async Task<IActionResult> SearchByGroupNameAsnyc(string fullName)
    {
        var result = await _mediator
            .Send(new SearchTeacherByFullNameQuery() { FullName = fullName });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsnyc(CreateTeacherDto dto)
    {
        var teacher = _mapper.Map<CreateTeacherCmd>(dto);

        var result = await _mediator.Send(teacher);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdateTeacherDto dto)
    {
        var teacher = _mapper.Map<UpdateTeacherCmd>(dto);
        teacher.Id = Id;
        var result = await _mediator.Send(teacher);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteTeacherCmd() { Id = Id });

        return Ok(result);
    }
}
