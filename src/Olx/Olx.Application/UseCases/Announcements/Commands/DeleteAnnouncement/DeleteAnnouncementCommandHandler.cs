using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;
using Olx.Application.Interfaces.Files;

namespace Olx.Application.UseCases.Announcements.Commands.DeleteAnnouncement;

public class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;
    private readonly IFileService _fileService;

    public DeleteAnnouncementCommandHandler(IMapper mapper,
        IAppDbContext context,
        IFileService fileService)
    {
        _mapper = mapper;
        _context = context;
        _fileService = fileService;
    }

    public async Task<bool> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var announcement = await _context.Announcements
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (announcement == null)
            return false;

        var imageResult = await _fileService
            .DeleteImageAsync(announcement.ImagePath);

        if (imageResult == false)
            throw new Exception("Image fot found!");

        _context.Announcements.Remove(announcement);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
