using Microsoft.EntityFrameworkCore;
using NIkoh.Domain.Entities.Marriages;
using NIkoh.Domain.Entities.Persons;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.Application.Abstractions;

public interface IAppDbContext
{
    public DbSet<Person> People { get; set; }

    public DbSet<Marriage> Marriages { get; set; }

    public DbSet<Requirement> Requirements { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
