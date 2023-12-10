using MediatR;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Announcements.Queries.GetByIdAnnouncement;

public class GetByIdAnnouncementQuery : IRequest<Announcement>
{
    public long Id { get; set; }
}
