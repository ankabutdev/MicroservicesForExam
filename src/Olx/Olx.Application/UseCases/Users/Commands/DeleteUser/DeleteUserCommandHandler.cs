using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (user == null)
            return false;

        _context.Users.Remove(user);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
