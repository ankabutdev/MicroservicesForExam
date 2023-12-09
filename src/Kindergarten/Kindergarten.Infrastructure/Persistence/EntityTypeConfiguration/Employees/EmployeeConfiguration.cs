using Kindergarten.Domain.Entities.Employees;
using Kindergarten.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.EntityTypeConfiguration.Employees;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.FullName)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.PhoneNumber)
            .IsRequired();

        builder.HasData(
            new Employee
            {
                Id = 1,
                FullName = "test1",
                Email = "test1",
                PhoneNumber = "test1",
                Gender = Gender.Male,
            },
            new Employee
            {
                Id = 2,
                FullName = "test2",
                Email = "test2",
                PhoneNumber = "test2",
                Gender = Gender.Female,
            },
            new Employee
            {
                Id = 3,
                FullName = "test3",
                Email = "test3",
                PhoneNumber = "test3",
                Gender = Gender.Male,
            });

    }
}
