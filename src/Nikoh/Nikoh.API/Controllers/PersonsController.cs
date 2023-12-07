using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nikoh.Application.UseCases.PersonCases.Commands;
using Nikoh.Application.UseCases.PersonCases.Queris;
using NIkoh.Domain.Dtos.Persons;
using NIkoh.Domain.Entities.Persons;

namespace Nikoh.API.Controllers;

[Route("api/persons")]
[ApiController]
public class PersonsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public PersonsController(IMapper mapper, IMediator mediator, IMemoryCache cache)
    {
        _mapper = mapper;
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllAdmins", out var cachedData))
        {
            var persons = (IEnumerable<Person>)cachedData!;
            return Ok(persons);
        }

        var result = await _mediator.Send(new GetAllPersonQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllPersons", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator
            .Send(new GetByIdPersonQuery() { Id = Id });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatePersonDto dto)
    {
        var person = _mapper.Map<CreatePersonCmd>(dto);

        var result = await _mediator.Send(person);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdatePersonDto dto)
    {
        var person = _mapper.Map<UpdatePersonCmd>(dto);
        person.Id = Id;
        var result = await _mediator.Send(person);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeletePersonCmd() { Id = Id });

        return Ok(result);
    }
}
