using GameClub.Application.Abstractions;
using GameClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace GameClub.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        try
        {
            if (databaseCreator is null)
            {
                throw new Exception("Database Not Found!");
            }

            if (!databaseCreator.CanConnect())
                databaseCreator.CreateAsync();

            if (!databaseCreator.HasTables())
                databaseCreator.CreateTablesAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<ScheduleOfChanges> ScheduleOfChanges { get; set; }

    public DbSet<Player> Players { get; set; }

    public DbSet<Computer> Computers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
