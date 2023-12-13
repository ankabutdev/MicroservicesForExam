using AutoMapper;
using MediatR;
using Olx.Application.Abstractions;
using Olx.Application.Interfaces.Files;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Announcements.Commands.CreateAnnouncement;

public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;
    private readonly IFileService _fileService;

    public CreateAnnouncementCommandHandler(IAppDbContext context,
        IMapper mapper,
        IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<bool> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Announcement>(request);

            string imagePath = await _fileService
                .UploadImageAsync(request.ImagePath);

            entity.ImagePath = imagePath;

            entity.UpdatedAt = DateTime.UtcNow;

            await _context.Announcements.AddAsync(entity, cancellationToken);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}