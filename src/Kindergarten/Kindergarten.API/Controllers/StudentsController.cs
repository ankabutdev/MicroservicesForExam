using AutoMapper;
using Kindergarten.Application.UseCases.StudentCase.Commands;
using Kindergarten.Application.UseCases.StudentCase.Queries;
using Kindergarten.Domain.Dtos.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.API.Controllers;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public StudentsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator
            .Send(new GetAllStudentQuery());

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetByIdStudentQuery() { Id = Id });

        return Ok(result);
    }

    [HttpGet("fullName")]
    public async Task<IActionResult> SearchByGroupNameAsnyc(string fullName)
    {
        var result = await _mediator
            .Send(new SearchStudentByFullNameQuery() { FullName = fullName });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsnyc(CreateStudnetDto dto)
    {
        var student = _mapper.Map<CreateStudentCmd>(dto);

        var result = await _mediator.Send(student);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateStudentDto dto)
    {
        var student = _mapper.Map<UpdateStudentCmd>(dto);

        var result = await _mediator.Send(student);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteStudentCmd() { Id = Id });

        return Ok(result);
    }
}
