using Kindergarten.Domain.Entities.Admins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarten.Infrastructure.Persistence.EntityTypeConfiguration.Admins;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasData(
            new Admin
            {
                Id = 1,
                Name = "test1",
                Password = "test1",
                Email = "testemail1"
            },
            new Admin
            {
                Id = 2,
                Name = "test2",
                Password = "test2",
                Email = "testemail2"
            },
            new Admin
            {
                Id = 3,
                Name = "test3",
                Password = "test3",
                Email = "testemail3"
            });
    }
}
