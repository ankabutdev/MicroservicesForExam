using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var announcement = await _context.Announcements
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (announcement is null)
                throw new ArgumentNullException(nameof(announcement));

            _mapper.Map(request, announcement);

            _context.Announcements.Update(announcement);

            var result = await _context
                .SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
