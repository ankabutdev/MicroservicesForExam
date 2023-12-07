using Kindergarten.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.EntityTypeConfiguration.Students;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(s => s.FullName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Gender).IsRequired();
        builder.Property(s => s.RegisteredAt).IsRequired();
        builder.Property(s => s.Address).HasMaxLength(255);
        builder.Property(s => s.DateOfBirth).IsRequired();

        builder.HasOne(s => s.Parent).WithMany(p => p.Students).HasForeignKey(s => s.ParentId);
        builder.HasOne(s => s.Group).WithMany(g => g.Students).HasForeignKey(s => s.GroupId);
    }
}
