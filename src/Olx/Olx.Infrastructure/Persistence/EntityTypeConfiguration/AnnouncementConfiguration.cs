using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olx.Domain.Entities;

namespace Olx.Infrastructure.Persistence.EntityTypeConfiguration;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired();
        builder.Property(a => a.Description);
        builder.Property(a => a.UserId).IsRequired();
        builder.Property(a => a.CategoryId).IsRequired();
        builder.Property(a => a.Title).IsRequired();
        builder.Property(a => a.ImagePath);
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt).IsRequired();

        builder.HasOne(a => a.User)
                 .WithMany(u => u.Announcements)
                 .HasForeignKey(a => a.UserId);

        builder.HasOne(a => a.Category)
            .WithMany(c => c.Announcements)
            .HasForeignKey(a => a.CategoryId);
    }
}
