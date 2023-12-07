using Kindergarten.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.EntityTypeConfiguration.Teachers;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(t => t.FullName).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Email).HasMaxLength(255);
        builder.Property(t => t.PhoneNumber).HasMaxLength(20);
        builder.Property(t => t.Address).HasMaxLength(255);

        builder.HasMany(t => t.Groups).WithMany(g => g.Teachers);
    }
}
