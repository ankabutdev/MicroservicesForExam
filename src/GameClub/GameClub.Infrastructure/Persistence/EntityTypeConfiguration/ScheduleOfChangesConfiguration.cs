using GameClub.Domain.Entities;
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
            .WithMany(x => x.ScheduleOfChanges);

    }
}
