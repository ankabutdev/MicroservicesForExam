using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.Infrastructure.Persitence.EntityTypeConfiguration;

public class RequirementConfiguration : IEntityTypeConfiguration<Requirement>
{
    public void Configure(EntityTypeBuilder<Requirement> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(r => r.Title).IsRequired().HasMaxLength(100);
        builder.Property(r => r.Description).HasMaxLength(255);

        builder.HasData(
                new Requirement
                {
                    Id = 1,
                    Title = "Title1",
                    Description = "Desk1"
                },
                new Requirement
                {
                    Id = 2,
                    Title = "Title2",
                    Description = "Desk2"
                },
                new Requirement
                {
                    Id = 3,
                    Title = "Title3",
                    Description = "Desk3"
                });
    }
}
