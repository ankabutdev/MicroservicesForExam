using AutoMapper;
using GameClub.Application.UseCases.AdminCases.Commands;
using GameClub.Application.UseCases.AdminCases.Queries;
using GameClub.Domain.DTOs.Admins;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace GameClub.API.Controllers;

[Route("api/admins")]
[ApiController]
public class AdminsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IDistributedCache _cache;

    public AdminsController(IMediator mediator,
        IDistributedCache cache,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        //var cachedData = await _cache.GetStringAsync("AllAdmins");

        //if (cachedData != null)
        //{
        //    var admin = JsonConvert.DeserializeObject<List<Admin>>(cachedData);
        //    return Ok(admin);
        //}

        var result = await _mediator.Send(new AdminGetAllQuery());

        //if (result != null)
        //{
        //    var cacheOptions = new DistributedCacheEntryOptions
        //    {
        //        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
        //        SlidingExpiration = TimeSpan.FromSeconds(20)
        //    };

        //    await _cache.SetStringAsync("AllAdmins", JsonConvert.SerializeObject(result), cacheOptions);
        //}

        return Ok(result);
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
    {
        var result = await _mediator.Send(new AdminGetByIdQuery() { Id = Id });
        return Ok(result);
    }

    [HttpGet("name")]
    public async Task<IActionResult> GetByNameAsync(string name)
    {
        var result = await _mediator
            .Send(new AdminGetByNameQuery()
            { Name = name });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(AdminCreateDto dto)
    {
        var adminCommand = _mapper.Map<CreateAdminCommand>(dto);
        var result = await _mediator.Send(adminCommand);
        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, AdminUpdateDto dto)
    {
        var updateAdmin = _mapper.Map<UpdateAdminCommand>(dto);
        updateAdmin.Id = Id;
        var result = await _mediator.Send(updateAdmin);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator.Send(new AdminDeleteCommand() { Id = Id });
        return Ok(result);
    }
}
