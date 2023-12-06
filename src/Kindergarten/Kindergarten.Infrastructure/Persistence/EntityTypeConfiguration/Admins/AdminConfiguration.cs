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
    }
}
