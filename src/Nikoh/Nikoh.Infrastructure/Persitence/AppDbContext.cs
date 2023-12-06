using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using NIkoh.Domain.Entities.Marriages;
using NIkoh.Domain.Entities.Persons;
using NIkoh.Domain.Entities.Requirements;
using System.Reflection;

namespace Nikoh.Infrastructure.Persitence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Requirement> Requirements { get; set; }

    public virtual DbSet<Marriage> Marriages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
