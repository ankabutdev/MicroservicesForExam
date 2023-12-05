using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ComputerCases.Commands;
using GameClub.Domain.Entities;
using GameClub.Domain.Exceptions.Computers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.ComputerCases.Handler.C;

public class ComputerUpdateCommandHandler : IRequestHandler<ComputerUpdateCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ComputerUpdateCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(ComputerUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var computer = await _context.Computers
            .FirstOrDefaultAsync(x => x.Version == request.Version);

        if (computer is not null)
            throw new ComputerAlreadyExistsExcption();

        computer = _mapper.Map<Computer>(request);

        _context.Computers.Update(computer);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
