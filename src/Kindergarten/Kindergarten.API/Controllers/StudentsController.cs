using AutoMapper;
using Kindergarten.Application.UseCases.StudentCase.Commands;
using Kindergarten.Application.UseCases.StudentCase.Queries;
using Kindergarten.Domain.Dtos.Students;
using Kindergarten.Domain.Entities.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Kindergarten.API.Controllers;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public StudentsController(IMapper mapper, IMediator mediator, IMemoryCache cache)
    {
        _mapper = mapper;
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllStudents", out var cachedData))
        {
            var students = (IEnumerable<Student>)cachedData!;
            return Ok(students);
        }

        var result = await _mediator.Send(new GetAllStudentQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllStudents", result, cacheEntryOptions);

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

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdateStudentDto dto)
    {
        var student = _mapper.Map<UpdateStudentCmd>(dto);
        student.Id = Id;
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
