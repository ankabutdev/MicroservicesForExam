using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NIkoh.Domain.Entities.Marriages;

namespace Nikoh.Infrastructure.Persitence.EntityTypeConfiguration;

public class MarriageConfiguration : IEntityTypeConfiguration<Marriage>
{
    public void Configure(EntityTypeBuilder<Marriage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.WomenId)
            .IsRequired();

        builder.HasData(
                new Marriage
                {
                    Id = 1,
                    CreatedAt = DateTime.UtcNow,
                    Description = "Description1",
                    Healthy = "test1",
                    ManId = 1,
                    RequirementId = 1,
                    WomenId = 2
                },
                new Marriage
                {
                    Id = 2,
                    CreatedAt = DateTime.UtcNow,
                    Description = "Description2",
                    Healthy = "test2",
                    ManId = 1,
                    RequirementId = 1,
                    WomenId = 2
                },
                new Marriage
                {
                    Id = 3,
                    CreatedAt = DateTime.UtcNow,
                    Description = "Description3",
                    Healthy = "test3",
                    ManId = 1,
                    RequirementId = 1,
                    WomenId = 2
                });
    }
}
