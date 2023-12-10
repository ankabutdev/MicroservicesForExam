using AutoMapper;
using MediatR;
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

    public Task<bool> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
