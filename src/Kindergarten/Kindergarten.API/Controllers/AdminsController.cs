using AutoMapper;
using Kindergarten.Application.UseCases.AdminCase.Queries;
using Kindergarten.Application.UseCases.AdminCases.Commands;
using Kindergarten.Domain.Dtos.Admins;
using Kindergarten.Domain.Entities.Admins;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Kindergarten.API.Controllers;

[Route("api/kgadmins")]
[ApiController]
public class AdminsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public AdminsController(IMediator mediator, IMapper mapper, IMemoryCache cache)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllKgAdmins", out var cachedData))
        {
            var admin = (IEnumerable<Admin>)cachedData!;
            return Ok(admin);
        }

        var result = await _mediator.Send(new GetAllAdminQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllKgAdmins", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator.Send(new GetByIdAdminQuery() { Id = Id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAdminDto dto)
    {
        var admin = _mapper.Map<CreateAdminCommand>(dto);

        var result = await _mediator.Send(admin);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, UpdateAdminDto dto)
    {
        var updateAdmin = _mapper.Map<UpdateAdminCommand>(dto);
        updateAdmin.Id = Id;
        var result = await _mediator.Send(updateAdmin);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator.Send(new DeleteAdminCommand() { Id = Id });
        return Ok(result);
    }

}
