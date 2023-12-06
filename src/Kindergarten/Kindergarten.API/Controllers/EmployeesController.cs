using AutoMapper;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Queries;
using Kindergarten.Domain.Dtos.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.API.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public EmployeesController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllEmpQuery());
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

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(EmployeeUpdateDto dto)
    {
        var employee = _mapper.Map<EmpUpdateCmd>(dto);

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
