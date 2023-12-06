using Kindergarten.Domain.Entities.Students;
using MediatR;

namespace Kindergarten.Application.UseCases.StudentCase.Queries;

public class SearchStudentByFullNameQuery : IRequest<IQueryable<Student>>
{
    public string FullName { get; set; }
}
