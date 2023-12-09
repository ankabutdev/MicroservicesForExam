using AutoMapper;
using Kindergarten.Application.UseCases.TeacherCase.Commands;
using Kindergarten.Application.UseCases.TeacherCase.Queries;
using Kindergarten.Domain.Dtos.Teachers;
using Kindergarten.Domain.Entities.Teachers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Kindergarten.API.Controllers;

[Route("api/teachers")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public TeachersController(IMapper mapper, IMediator mediator, IMemoryCache cache)
    {
        _mapper = mapper;
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllTeachers", out var cachedData))
        {
            var teachers = (IEnumerable<Teacher>)cachedData!;
            return Ok(teachers);
        }

        var result = await _mediator.Send(new GetAllTeacherQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllTeachers", result, cacheEntryOptions);

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
