using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olx.Domain.Entities;

namespace Olx.Infrastructure.Persistence.EntityTypeConfiguration;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcements>
{
    public void Configure(EntityTypeBuilder<Announcements> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired();
        builder.Property(a => a.Description);
        builder.Property(a => a.UserId).IsRequired();
        builder.Property(a => a.CategortId).IsRequired();
        builder.Property(a => a.Title).IsRequired();
        builder.Property(a => a.ImagePath);
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt).IsRequired();

        builder.HasOne(a => a.User)
            .WithMany(u => u.Announcements)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Category)
            .WithMany(c => c.Announcements)
            .HasForeignKey(a => a.CategortId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
