using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Handlers.C;
using Kindergarten.Domain.Entities.Employees;
using Kindergarten.Domain.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace Kindergarten.UnitTest.Services.Employees;

public class EmployeeTests
{
    [Fact]
    public async Task ShouldReturnFalseWhenEmployeeCreateIsInvalid()
    {
        // Arrange
        var command = new EmpCreateCmd
        {
            Email = "invalid_email",
            FullName = "test",
            Gender = Gender.Male,
            PhoneNumber = "1234567890",
        };

        var dbContextMock = new Mock<IAppDbContext>();
        var mapperMock = new Mock<IMapper>();

        // Mock the mapping
        mapperMock
            .Setup(x => x.Map<Employee>(command))
            .Returns(new Employee());

        // Mock Add method
        dbContextMock.Setup(x => x.Employees.Add(It.IsAny<Employee>()))
            .Returns(Mock.Of<EntityEntry<Employee>>(_ => _.Entity == new Employee()));

        // Mock SaveChangesAsync method
        dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);


        var handler = new CreateEmpCmdHandler(dbContextMock.Object, mapperMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async ValueTask ShouldReturnTrueWhenEmployeeUpdateIsValid()
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

        var dbContextMock = new Mock<IAppDbContext>();
        var mapperMock = new Mock<IMapper>();

        //mapperMock.Setup(x => x
        //.Map<Employee>(command))
        //.Returns(new Employee());

        mapperMock.Verify(x => x.Map<Employee>(command), Times.Once);
        dbContextMock.Verify(x => x.Employees.Update(It.IsAny<Employee>()), Times.Once);
        dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        var handler = new UpdateEmpCmdHandler(dbContextMock.Object, mapperMock.Object);
        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert 
        Assert.True(result);
    }

    [Fact]
    public async ValueTask ShouldReturnTrueWhenEmployeeDeleteIsValid()
    {
        var dbContextMock = new Mock<IAppDbContext>();

        var command = new EmpDeleteCmd
        {
            Id = 1
        };

        dbContextMock
            .Verify(x => x
            .Employees
            .FirstOrDefault(x => x
            .Id == command.Id), Times.Once);

        dbContextMock
            .Verify(x => x
            .SaveChangesAsync(It
            .IsAny<CancellationToken>()), Times.Once);

        var handler = new DeleteEmpCmdHandler(dbContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result);
    }
}
