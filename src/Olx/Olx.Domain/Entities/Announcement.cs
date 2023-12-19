namespace Olx.Domain.Entities;

public class Announcement
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public string Description { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; }

    public string Title { get; set; }

    public string ImagePath { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

}
