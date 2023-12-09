using GameClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameClub.Infrastructure.Persistence.EntityTypeConfiguration;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Password)
            .IsRequired();

        builder.HasMany(x => x.ScheduleOfChanges)
            .WithOne(x => x.Admin)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new Admin
            {
                Id = 1,
                Name = "test1",
                Password = "test1",
                ScheduleOfChanges = []
            },
            new Admin
            {
                Id = 2,
                Name = "test2",
                Password = "test2",
                ScheduleOfChanges = []
            },
            new Admin
            {
                Id = 3,
                Name = "test3",
                Password = "test3",
                ScheduleOfChanges = []
            });
    }
}
