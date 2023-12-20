using Kindergarten.Application.Abstractions;
using Kindergarten.Application.Mappers;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Handlers.C;
using Kindergarten.Domain.Entities.Employees;
using Kindergarten.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kindergarten.UnitTest.Services.Employees;

public class EmployeeTests
{
    private readonly IMapper _mapper;
    private Mock<IAppDbContext> _dbContextMock;

    public EmployeeTests()
    {
        _dbContextMock = new Mock<IAppDbContext>();
        var config = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingConfiguration>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public async Task ShouldReturnTrueWhenEmployeeCreateIsValid()
    {
        // Arrange
        var command = new EmpCreateCmd
        {
            Email = "invalid_email",
            FullName = "test",
            Gender = Gender.Male,
            PhoneNumber = "1234567890",
        };

        // Mock Add method
        _dbContextMock.Setup(x => x.Employees.AddAsync(It.IsAny<Employee>(), CancellationToken.None));

        // Mock SaveChangesAsync method
        _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var handler = new CreateEmpCmdHandler(_dbContextMock.Object, _mapper);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task ShouldReturnTrueWhenEmployeeUpdateIsValid()
    {
        // Arrange
        var command = new EmpUpdateCmd
        {
            Id = 1,
            Email = "email",
            FullName = "test",
            Gender = Gender.Male,
            PhoneNumber = "1234567890"
        };

        _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var handler = new UpdateEmpCmdHandler(_dbContextMock.Object, _mapper);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task ShouldReturnTrueWhenEmployeeDeleteIsValid()
    {
        var command = new EmpDeleteCmd
        {
            Id = 1
        };

        _dbContextMock
            .Setup(x => x.Employees.FirstOrDefaultAsync(It
            .IsAny<Expression<Func<Employee, bool>>>(), It
            .IsAny<CancellationToken>()))
            .ReturnsAsync(new Employee());

        _dbContextMock
            .Setup(x => x.SaveChangesAsync(It
            .IsAny<CancellationToken>()))
            .ReturnsAsync(It.IsAny<int>());

        var handler = new DeleteEmpCmdHandler(_dbContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result);
    }
}
