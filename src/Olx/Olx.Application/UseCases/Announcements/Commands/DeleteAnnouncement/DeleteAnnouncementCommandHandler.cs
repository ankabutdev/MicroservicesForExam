using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;

namespace Olx.Application.UseCases.Announcements.Commands.DeleteAnnouncement;

public class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public DeleteAnnouncementCommandHandler(IMapper mapper, IAppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var announcement = await _context.Announcements
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (announcement == null)
            return false;

        _context.Announcements.Remove(announcement);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
