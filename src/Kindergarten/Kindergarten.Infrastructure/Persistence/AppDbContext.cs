using Kindergarten.Application.Abstractions;
using Kindergarten.Domain.Entities.Admins;
using Kindergarten.Domain.Entities.Employees;
using Kindergarten.Domain.Entities.Groups;
using Kindergarten.Domain.Entities.Parents;
using Kindergarten.Domain.Entities.Students;
using Kindergarten.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kindergarten.Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options) { }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Parent> Parents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
