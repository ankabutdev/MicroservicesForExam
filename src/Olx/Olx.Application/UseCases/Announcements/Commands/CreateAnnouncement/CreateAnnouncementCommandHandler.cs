using AutoMapper;
using MediatR;
using Olx.Application.Abstractions;

namespace Olx.Application.UseCases.Announcements.Commands.CreateAnnouncement;

public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public CreateAnnouncementCommandHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<bool> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}