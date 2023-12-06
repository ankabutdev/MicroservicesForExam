using Kindergarten.Domain.Entities.Students;
using MediatR;

namespace Kindergarten.Application.UseCases.StudentCase.Queries;

public class GetByIdStudentQuery : IRequest<Student>
{
    public long Id { get; set; }
}
