using Kindergarten.Domain.Entities.Teachers;
using MediatR;

namespace Kindergarten.Application.UseCases.TeacherCase.Queries;

public class GetAllTeacherQuery : IRequest<IEnumerable<Teacher>>
{
}
