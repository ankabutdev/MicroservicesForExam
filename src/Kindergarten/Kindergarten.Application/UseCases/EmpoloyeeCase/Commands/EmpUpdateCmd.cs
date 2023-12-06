using Kindergarten.Domain.Enums;
using MediatR;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;

public class EmpUpdateCmd : IRequest<bool>
{
    public long Id { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public Gender Gender { get; set; }
}
