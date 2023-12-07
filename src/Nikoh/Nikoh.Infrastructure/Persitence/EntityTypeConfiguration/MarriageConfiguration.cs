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


    }
}
