using AutoMapper;
using MediatR;
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

    public Task<Announcement> Handle(GetByIdAnnouncementQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
