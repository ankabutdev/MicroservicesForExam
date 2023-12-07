using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Nikoh.Application.Abstractions;
using Nikoh.Infrastructure.Persitence.EntityTypeConfiguration;
using NIkoh.Domain.Entities.Marriages;
using NIkoh.Domain.Entities.Persons;
using NIkoh.Domain.Entities.Requirements;
using System.Reflection;

namespace Nikoh.Infrastructure.Persitence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
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

    public DbSet<Person> People { get; set; }

    public DbSet<Marriage> Marriages { get; set; }

    public DbSet<Requirement> Requirements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfiguration<Marriage>(new MarriageConfiguration());
    }

    async ValueTask<int> IAppDbContext.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
