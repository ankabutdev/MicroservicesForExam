using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;
using Olx.Domain.Entities;

namespace Olx.Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Announcements> Announcements { get; set; }

    public DbSet<Category> Categories { get; set; }

    async ValueTask<int> IAppDbContext.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
