using GameClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Admin> Admins { get; set; }

    DbSet<ScheduleOfChanges> ScheduleOfChanges { get; set; }

    DbSet<Player> Players { get; set; }

    DbSet<Computer> Computers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
