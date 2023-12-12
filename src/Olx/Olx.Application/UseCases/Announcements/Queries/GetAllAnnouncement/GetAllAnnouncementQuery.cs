using MediatR;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Announcements.Queries.GetAllAnnouncement;

public class GetAllAnnouncementQuery : IRequest<IEnumerable<Announcement>>
{
}
