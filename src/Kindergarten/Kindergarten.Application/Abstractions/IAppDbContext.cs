using Kindergarten.Domain.Entities.Admins;
using Kindergarten.Domain.Entities.Employees;
using Kindergarten.Domain.Entities.Groups;
using Kindergarten.Domain.Entities.Parents;
using Kindergarten.Domain.Entities.Students;
using Kindergarten.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.Abstractions;

public interface IAppDbContext
{
    DbSet<Admin> Admins { get; set; }

    DbSet<Employee> Employees { get; set; }

    DbSet<Student> Students { get; set; }

    DbSet<Group> Groups { get; set; }

    DbSet<Teacher> Teachers { get; set; }

    DbSet<Parent> Parents { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
