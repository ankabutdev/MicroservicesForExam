using Kindergarten.Domain.Entities.Teachers;
using MediatR;

namespace Kindergarten.Application.UseCases.TeacherCase.Queries;

public class GetByIdTeacherQuery : IRequest<Teacher>
{
    public long Id { get; set; }
}
