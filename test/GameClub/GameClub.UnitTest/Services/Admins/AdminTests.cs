using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Commands;
using GameClub.Application.UseCases.AdminCases.Handler;
using GameClub.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace GameClub.UnitTest.Services.Admins;

public class AdminTests
{
    [Fact]
    public async ValueTask ShouldReturnTrueWhenAdminCreateIsValid()
    {
        // Arrange
        var command = new CreateAdminCommand
        {
            Name = "TestAdmin",
            Password = "TestPassword"
        };

        var dbContextMock = new Mock<IApplicationDbContext>();
        var mapperMock = new Mock<IMapper>();

        var handler = new CreateAdminCommandHandler(dbContextMock.Object, mapperMock.Object);

        // Mock the mapping
        mapperMock
            .Setup(x => x
            .Map<Admin>(command))
            .Returns(new Admin());

        // Mock the DbContext behavior
        dbContextMock
            .Setup(x => x
            .Admins
            .AddAsync(It
            .IsAny<Admin>(), It
            .IsAny<CancellationToken>()))
            .Returns(ValueTask
            .FromResult(Mock
            .Of<EntityEntry<Admin>>(_ => _
            .Entity == new Admin())));

        dbContextMock
        .Setup(x => x
        .SaveChangesAsync(It
        .IsAny<CancellationToken>()))
        .ReturnsAsync(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async ValueTask ShouldReturnTrueWhenAdminUpdateIsValidAsync()
    {
        // Arrange 
        var command = new UpdateAdminCommand
        {
            Name = "TestAdmin",
            Password = "TestPassword"
        };

        var dbContextMock = new Mock<IApplicationDbContext>();
        var mapperMock = new Mock<IMapper>();

        var handler = new UpdateAdminCommandHandler(dbContextMock.Object, mapperMock.Object);

        // Mock the mapping
        mapperMock.Setup(x => x
        .Map<Admin>(command))
        .Returns(new Admin());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);

        // Verify mock invocations
        mapperMock.Verify(x => x.Map<Admin>(command), Times.Once);

        // Verify that the Update method was called with any Admin instance
        dbContextMock.Verify(x => x.Admins.Update(It.IsAny<Admin>()), Times.Once);

        // Verify that SaveChangesAsync was called with any CancellationToken
        dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    //[Fact]
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(-1)]
    public async ValueTask ShouldReturnTrueWhenAdminDeleteIsValid(int Id)
    {
        var dbContextMock = new Mock<IApplicationDbContext>();


        var command = new AdminDeleteCommand()
        {
            Id = Id
        };

        var handler = new AdminDeleteCommandHandler(dbContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);

        dbContextMock
            .Verify(x => x
            .Admins
            .FirstOrDefault(x => x
            .Id == Id), Times.Once);

        //Assert.False(dbContextMock.Object.Admins.FirstOrDefault(x => x.Id == Id)!.Id > 0, "fail");

        dbContextMock
            .Verify(x => x
            .Admins
            .Remove(It
            .IsAny<Admin>()), Times.Once);

        dbContextMock
            .Verify(x => x
            .SaveChangesAsync(It
            .IsAny<CancellationToken>()), Times.Once);
    }
}
