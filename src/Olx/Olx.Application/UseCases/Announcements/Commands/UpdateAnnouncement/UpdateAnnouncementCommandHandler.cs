using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;
using Olx.Application.Interfaces.Files;

namespace Olx.Application.UseCases.Announcements.Commands.UpdateAnnouncement;

public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;
    private readonly IFileService _fileService;

    public UpdateAnnouncementCommandHandler(IAppDbContext context,
        IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<bool> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var announcement = await _context.Announcements
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (announcement is null)
                throw new ArgumentNullException(nameof(announcement));

            if (request.ImagePath is not null)
            {
                var deleteImage = await _fileService.DeleteImageAsync(announcement.ImagePath);

                string newImagePath = await _fileService.UploadImageAsync(request.ImagePath);

                announcement.ImagePath = newImagePath;
            }



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
