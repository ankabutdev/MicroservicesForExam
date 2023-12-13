using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Announcements.Queries.GetByIdAnnouncement;

public class GetByIdAnnouncementQueryHandler : IRequestHandler<GetByIdAnnouncementQuery, Announcement>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdAnnouncementQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Announcement> Handle(GetByIdAnnouncementQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Announcements
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Announcement not found!");
    }
}
