using GameClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameClub.Infrastructure.Persistence.EntityTypeConfiguration;

public class ComputerConfiguration : IEntityTypeConfiguration<Computer>
{
    public void Configure(EntityTypeBuilder<Computer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasMany(x => x.Players)
            .WithOne(x => x.Computer);

        builder.HasIndex(x => x.Version)
            .IsUnique();

        builder.Property(x => x.Version)
            .IsRequired();

        builder.Property(x => x.PriceOfHour)
            .IsRequired();

        builder.HasMany(x => x.Players)
            .WithOne(x => x.Computer)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
