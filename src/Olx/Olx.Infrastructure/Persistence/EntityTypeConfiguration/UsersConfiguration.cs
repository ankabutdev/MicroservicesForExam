using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olx.Domain.Entities;

namespace Olx.Infrastructure.Persistence.EntityTypeConfiguration;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).IsRequired();
        builder.Property(u => u.LastName).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.PhoneNumber);
        builder.Property(u => u.UserName).IsRequired();
        builder.Property(u => u.Address);
        builder.Property(u => u.Role).IsRequired();

        builder.HasMany(u => u.Announcements)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
