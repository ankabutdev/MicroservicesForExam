using MediatR;

namespace Kindergarten.Application.UseCases.StudentCase.Commands;

public class DeleteStudentCmd : IRequest<bool>
{
    public long Id { get; set; }
}
