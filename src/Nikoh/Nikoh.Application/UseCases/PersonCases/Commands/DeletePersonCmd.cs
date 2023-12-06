using MediatR;

namespace Nikoh.Application.UseCases.PersonCases.Commands;

public class DeletePersonCmd : IRequest<bool>
{
    public long Id { get; set; }
}
