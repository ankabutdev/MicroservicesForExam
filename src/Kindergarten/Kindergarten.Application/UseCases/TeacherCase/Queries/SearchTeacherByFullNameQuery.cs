using Kindergarten.Domain.Entities.Teachers;
using MediatR;

namespace Kindergarten.Application.UseCases.TeacherCase.Queries;

public class SearchTeacherByFullNameQuery : IRequest<IQueryable<Teacher>>
{
    public string FullName { get; set; }
}
