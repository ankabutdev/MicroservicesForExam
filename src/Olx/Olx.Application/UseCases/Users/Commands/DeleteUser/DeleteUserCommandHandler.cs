using AutoMapper;
using MediatR;
using Olx.Application.Abstractions;

namespace Olx.Application.UseCases.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public DeleteUserCommandHandler(IMapper mapper, IAppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
