using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NIkoh.Domain.Entities.Persons;

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
    }
}
