using Microsoft.EntityFrameworkCore;
using NIkoh.Domain.Entities.Marriages;
using NIkoh.Domain.Entities.Persons;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.Application.Abstractions;

public interface IAppDbContext
{
    DbSet<Person> People { get; set; }

    DbSet<Marriage> Marriages { get; set; }

    DbSet<Requirement> Requirements { get; set; }

    public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
