using Kindergarten.Domain.Entities.Parents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.EntityTypeConfiguration.Parents;

public class ParentConfiguration : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(p => p.MotherFullName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.FatherFullName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.PassportSeriaNumber).IsRequired().HasMaxLength(20);
        builder.Property(p => p.PhoneNumber).HasMaxLength(20);
        builder.Property(p => p.Email).HasMaxLength(255);
        builder.Property(p => p.Address).HasMaxLength(255);

        builder.HasMany(p => p.Students).WithOne(s => s.Parent).HasForeignKey(s => s.ParentId);

        builder.HasData(
            new Parent
            {
                Id = 1,
                Address = "test1",
                Email = "test1",
                FatherFullName = "test1",
                MotherFullName = "test1",
                PassportSeriaNumber = "test1",
                PhoneNumber = "test1",
            },
            new Parent
            {
                Id = 2,
                Address = "test2",
                Email = "test3",
                FatherFullName = "test3",
                MotherFullName = "test3",
                PassportSeriaNumber = "test3",
                PhoneNumber = "test3",
            },
            new Parent
            {
                Id = 3,
                Address = "test3",
                Email = "test3",
                FatherFullName = "test3",
                MotherFullName = "test3",
                PassportSeriaNumber = "test3",
                PhoneNumber = "test3",
            });

    }
}
