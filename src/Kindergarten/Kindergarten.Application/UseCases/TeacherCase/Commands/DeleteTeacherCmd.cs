using MediatR;

namespace Kindergarten.Application.UseCases.TeacherCase.Commands;

public class DeleteTeacherCmd : IRequest<bool>
{
    public long Id { get; set; }
}
