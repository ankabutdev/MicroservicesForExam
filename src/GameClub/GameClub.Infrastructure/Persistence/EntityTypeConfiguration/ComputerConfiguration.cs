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

        builder.HasData(
            new Computer
            {
                Id = 1,
                Name = "test1",
                PriceOfHour = 10,
                Version = "1.0",
                Players = []
            },
            new Computer
            {
                Id = 2,
                Name = "test2",
                PriceOfHour = 11,
                Version = "2.0",
                Players = []
            },
            new Computer
            {
                Id = 3,
                Name = "test3",
                PriceOfHour = 12,
                Version = "3.0",
                Players = []
            });

    }
}
