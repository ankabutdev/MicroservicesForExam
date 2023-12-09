using Kindergarten.Domain.Entities.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.EntityTypeConfiguration.Groups;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(g => g.Name).IsRequired().HasMaxLength(100);
        builder.Property(g => g.Description).HasMaxLength(255);
        builder.Property(g => g.AgeGroup).IsRequired();
        builder.Property(g => g.StartDate).IsRequired();
        builder.Property(g => g.EndDate).IsRequired();

        builder.HasMany(g => g.Students).WithOne(s => s.Group).HasForeignKey(s => s.GroupId);
        builder.HasMany(g => g.Teachers).WithMany(t => t.Groups);

        builder.HasData(
            new Group
            {
                Id = 1,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MaxValue,
                AgeGroup = 3,
                Description = "Description1",
                Name = "test1"
            },
            new Group
            {
                Id = 2,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MaxValue,
                AgeGroup = 2,
                Description = "Description2",
                Name = "test2"
            },
            new Group
            {
                Id = 3,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MaxValue,
                AgeGroup = 1,
                Description = "Description3",
                Name = "test3"
            });

    }
}
