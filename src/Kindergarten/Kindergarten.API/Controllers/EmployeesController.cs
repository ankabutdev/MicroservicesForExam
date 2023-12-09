using AutoMapper;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Queries;
using Kindergarten.Domain.Dtos.Employees;
using Kindergarten.Domain.Entities.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Kindergarten.API.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;

    public EmployeesController(IMapper mapper, IMediator mediator, IMemoryCache cache)
    {
        _mapper = mapper;
        _mediator = mediator;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        if (_cache.TryGetValue("AllEmployees", out var cachedData))
        {
            var emp = (IEnumerable<Employee>)cachedData!;
            return Ok(emp);
        }

        var result = await _mediator.Send(new GetAllEmpQuery());

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
            SlidingExpiration = TimeSpan.FromSeconds(20)
        };

        _cache.Set("AllEmployees", result, cacheEntryOptions);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(long Id)
    {
        var result = await _mediator
            .Send(new GetByIdEmpQuery() { Id = Id });

        return Ok(result);
    }

    [HttpGet("email")]
    public async Task<IActionResult> SearchByEmailAsync(string email)
    {
        var result = await _mediator
            .Send(new SearchEmpByEmailQuery() { Email = email });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(EmployeeCreateDto dto)
    {
        var employee = _mapper.Map<EmpCreateCmd>(dto);

        var result = await _mediator.Send(employee);

        return Ok(result);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(long Id, EmployeeUpdateDto dto)
    {
        var employee = _mapper.Map<EmpUpdateCmd>(dto);
        employee.Id = Id;
        var result = await _mediator.Send(employee);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var result = await _mediator
            .Send(new EmpDeleteCmd() { Id = Id });

        return Ok(result);
    }

}
