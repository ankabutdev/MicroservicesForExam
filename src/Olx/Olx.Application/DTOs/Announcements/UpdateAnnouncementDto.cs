namespace Olx.Application.DTOs.Announcements;

public class UpdateAnnouncementDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long UserId { get; set; }

    public string Description { get; set; }

    public long CategortId { get; set; }

    public string Title { get; set; }

    public string ImagePath { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
