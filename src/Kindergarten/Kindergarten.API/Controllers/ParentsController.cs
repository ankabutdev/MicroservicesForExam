using AutoMapper;
using Kindergarten.Application.UseCases.ParentCase.Commands;
using Kindergarten.Application.UseCases.ParentCase.Queries;
using Kindergarten.Domain.Dtos.Parents;
using Kindergarten.Domain.Entities.Parents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Kindergarten.API.Controllers;

[Route("api/parents")]
[ApiController]
public class ParentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public ParentsController(IMapper mapper, IMediator mediator, IMemoryCache cache)
    {
        _mapper = mapper;
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllParents", out var cachedData))
        {
            var parents = (IEnumerable<Parent>)cachedData!;
            return Ok(parents);
        }

        var result = await _mediator.Send(new GetAllParentQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllParents", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("phoneNumber")]
    public async Task<IActionResult> SearchByPhoneNumberAsync(string phoneNumber)
    {
        var result = await _mediator
            .Send(new SearchParentByPhoneNumberQuery()
            { PhoneNumber = phoneNumber });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateParentDto dto)
    {
        var parent = _mapper.Map<CreateParentCmd>(dto);

        var result = await _mediator.Send(parent);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdateParentDto dto)
    {
        var parent = _mapper.Map<UpdateParentCmd>(dto);
        parent.Id = Id;
        var result = await _mediator.Send(parent);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new DeleteParentCmd() { Id = Id });

        return Ok(result);
    }
}
