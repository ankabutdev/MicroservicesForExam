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
    }
}
