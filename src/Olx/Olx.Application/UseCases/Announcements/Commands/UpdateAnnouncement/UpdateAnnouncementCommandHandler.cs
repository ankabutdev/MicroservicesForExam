using AutoMapper;
using MediatR;
using Olx.Application.Abstractions;

namespace Olx.Application.UseCases.Announcements.Commands.UpdateAnnouncement;

public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public UpdateAnnouncementCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<bool> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
