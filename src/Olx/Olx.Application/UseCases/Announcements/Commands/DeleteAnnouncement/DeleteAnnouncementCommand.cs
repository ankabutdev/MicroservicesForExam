using MediatR;

namespace Olx.Application.UseCases.Announcements.Commands.DeleteAnnouncement;

public class DeleteAnnouncementCommand : IRequest<bool>
{
    public long Id { get; set; }
}
