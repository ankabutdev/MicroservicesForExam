namespace Olx.Domain.Entities;

public class Category
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<Announcements> Announcements { get; set; }
}
