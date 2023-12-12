using GameClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameClub.Infrastructure.Persistence.EntityTypeConfiguration;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.HasMany(x => x.ScheduleOfChanges)
            .WithOne(x => x.Player)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new Player
            {
                Id = 1,
                NickName = "test1",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                HoursCount = 1,
                ComputerId = 2,
            },
            new Player
            {
                Id = 2,
                NickName = "test1",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                HoursCount = 1,
                ComputerId = 2,
                ScheduleOfChanges = [],
            },
            new Player
            {
                Id = 3,
                NickName = "test1",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                HoursCount = 1,
                ComputerId = 2,
            }) ;
    }
}
