using Microsoft.EntityFrameworkCore;
using Olx.Domain.Entities;

namespace Olx.Application.Abstractions;

public interface IAppDbContext
{
    DbSet<User> Users { get; set; }

    DbSet<Announcement> Announcements { get; set; }

    DbSet<Category> Categories { get; set; }

    ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}