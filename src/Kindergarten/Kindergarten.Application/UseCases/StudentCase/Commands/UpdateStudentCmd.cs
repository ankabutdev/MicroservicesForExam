using Kindergarten.Domain.Enums;
using MediatR;

namespace Kindergarten.Application.UseCases.StudentCase.Commands;

public class UpdateStudentCmd : IRequest<bool>
{
    public long Id { get; set; }

    public string FullName { get; set; }

    public Gender Gender { get; set; }

    public DateTime RegisteredAt { get; set; }

    public string Address { get; set; }

    public DateTime DateOfBirth { get; set; }

    public long ParentId { get; set; }

    public long GroupId { get; set; }

}
