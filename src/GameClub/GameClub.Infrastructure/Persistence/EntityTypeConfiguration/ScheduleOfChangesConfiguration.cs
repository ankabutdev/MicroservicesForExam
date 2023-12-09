using GameClub.Domain.Entities;
using GameClub.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameClub.Infrastructure.Persistence.EntityTypeConfiguration;

public class ScheduleOfChangesConfiguration : IEntityTypeConfiguration<ScheduleOfChanges>
{
    public void Configure(EntityTypeBuilder<ScheduleOfChanges> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(256);

        builder.HasOne(x => x.Admin)
            .WithMany(x => x.ScheduleOfChanges)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
                    new ScheduleOfChanges
                    {
                        Id = 1,
                        Description = "test1",
                        Status = ChangesStatus.Started,
                        TotalPrice = 12,
                        AdminId = 2
                    },
                    new ScheduleOfChanges
                    {
                        Id = 2,
                        Description = "test2",
                        Status = ChangesStatus.Started,
                        TotalPrice = 12,
                        AdminId = 2
                    },
                    new ScheduleOfChanges
                    {
                        Id = 3,
                        Description = "test3",
                        Status = ChangesStatus.Playing,
                        TotalPrice = 12,
                        AdminId = 2
                    });

    }
}
