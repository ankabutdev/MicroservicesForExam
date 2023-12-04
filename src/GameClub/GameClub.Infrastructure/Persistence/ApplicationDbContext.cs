using GameClub.Application.Abstractions;
using GameClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GameClub.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<ScheduleOfChanges> ScheduleOfChanges { get; set; }

    public DbSet<Player> Players { get; set; }

    public DbSet<Computer> Computers { get; set; }

    public DbSet<History> Histories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
