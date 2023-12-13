using Microsoft.AspNetCore.Http;

namespace Olx.Application.DTOs.Announcements;

public class CreateAnnouncementDto
{
    public string Name { get; set; }

    public long UserId { get; set; }

    public string Description { get; set; }

    public long CategortId { get; set; }

    public string Title { get; set; }

    public IFormFile ImagePath { get; set; } = default!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
