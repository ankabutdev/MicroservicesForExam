using MediatR;
using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Announcements.Queries.GetAllAnnouncement;

public class GetAllAnnouncementQueryHandler : IRequestHandler<GetAllAnnouncementQuery, IEnumerable<Announcement>>
{
    private readonly IAppDbContext _context;

    public GetAllAnnouncementQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Announcement>> Handle(GetAllAnnouncementQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Announcements
            .Include(x => x.User)
            //.ThenInclude(y => y.Announcements)
            .ToListAsync(cancellationToken);
    }
}
