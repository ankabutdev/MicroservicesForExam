using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NIkoh.Domain.Entities.Persons;
using NIkoh.Domain.Enums;

namespace Nikoh.Infrastructure.Persitence.EntityTypeConfiguration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.MiddleName).HasMaxLength(100);
        builder.Property(p => p.PassportSeriaNumber).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Age).IsRequired();
        builder.Property(p => p.Address).HasMaxLength(255);
        builder.Property(p => p.Healthy).HasMaxLength(255);
        builder.Property(p => p.DateOfBirth).IsRequired();
        builder.Property(p => p.Gender).IsRequired();

        builder.HasData(
                new Person
                {
                    Id = 1,
                    Address = "test1",
                    Age = 5,
                    DateOfBirth = DateTime.MinValue,
                    FirstName = "test1",
                    LastName = "test1",
                    Gender = Gender.Male,
                    Healthy = "test1",
                    MiddleName = "test1",
                    PassportSeriaNumber = "test1"
                },
                new Person
                {
                    Id = 2,
                    Address = "test2",
                    Age = 1,
                    DateOfBirth = DateTime.MinValue,
                    FirstName = "test2",
                    LastName = "test2",
                    Gender = Gender.Female,
                    Healthy = "test2",
                    MiddleName = "test2",
                    PassportSeriaNumber = "test2"
                },
                new Person
                {
                    Id = 3,
                    Address = "test3",
                    Age = 1,
                    DateOfBirth = DateTime.MinValue,
                    FirstName = "test3",
                    LastName = "test3",
                    Gender = Gender.Female,
                    Healthy = "test3",
                    MiddleName = "test3",
                    PassportSeriaNumber = "test3"
                });
    }
}
