using Kindergarten.Domain.Entities.Students;
using Kindergarten.Domain.Enums;
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

        builder.HasData(
            new Student
            {
                Id = 1,
                Address = "test1",
                RegisteredAt = DateTime.UtcNow,
                DateOfBirth = DateTime.UtcNow,
                FullName = "test1",
                Gender = Gender.Male,
                GroupId = 1,
                ParentId = 2
            },
            new Student
            {
                Id = 2,
                Address = "test2",
                RegisteredAt = DateTime.UtcNow,
                DateOfBirth = DateTime.UtcNow,
                FullName = "test2",
                Gender = Gender.Female,
                GroupId = 1,
                ParentId = 2
            },
            new Student
            {
                Id = 3,
                Address = "test3",
                RegisteredAt = DateTime.UtcNow,
                DateOfBirth = DateTime.UtcNow,
                FullName = "test3",
                Gender = Gender.Male,
                GroupId = 1,
                ParentId = 2
            });

    }
}
