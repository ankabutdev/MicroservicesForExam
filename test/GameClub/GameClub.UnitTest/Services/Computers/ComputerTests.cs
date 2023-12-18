using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ComputerCases.Commands;
using GameClub.Application.UseCases.ComputerCases.Handler.C;
using GameClub.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace GameClub.UnitTest.Services.Computers;

public class ComputerTests
{
    [Fact]
    public async ValueTask ShouldReturnTrueWhenComputerCreateIsValid()
    {
        // Arrange
        var command = new ComputerCreateCommand
        {
            Name = "name",
            PriceOfHour = 10,
            Version = "v1"
        };

        var dbContextMock = new Mock<IApplicationDbContext>();
        var mapperMock = new Mock<IMapper>();

        var handler = new ComputerCreateCommandHandler(dbContextMock.Object, mapperMock.Object);

        // Mock the mapping
        mapperMock
            .Setup(x => x
            .Map<Computer>(command))
            .Returns(new Computer());

        dbContextMock.Setup(x => x
        .Computers
        .AddAsync(It.IsAny<Computer>(), It
        .IsAny<CancellationToken>()))
        .Returns(ValueTask
        .FromResult(Mock
        .Of<EntityEntry<Computer>>(x => x
        .Entity == new Computer())));

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
    public async ValueTask ShouldReturnTrueWhenComputerUpdateIsValid()
    {
        // Arrange
        var command = new ComputerUpdateCommand
        {
            Id = 1,
            Name = "name",
            PriceOfHour = 10,
            Version = "v2"
        };

        var dbContextMock = new Mock<IApplicationDbContext>();
        var mapperMock = new Mock<IMapper>();

        var handler = new ComputerUpdateCommandHandler(dbContextMock.Object, mapperMock.Object);

        mapperMock.Setup(x => x
        .Map<Computer>(command))
        .Returns(new Computer());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert 
        Assert.True(result);

        mapperMock.Verify(x => x.Map<Computer>(command), Times.Once);

        dbContextMock.Verify(x => x.Computers.Update(It.IsAny<Computer>()), Times.Once);

        dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async ValueTask ShouldReturnTrueWhenComputerDeleteIsValid()
    {
        var dbContextMock = new Mock<IApplicationDbContext>();

        var command = new ComputerDeleteCommand
        {
            Id = 1
        };

        var handler = new ComputerDeleteCommandHandler(dbContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result);

        dbContextMock
            .Verify(x => x
            .Computers
            .FirstOrDefault(x => x
            .Id == command.Id), Times.Once);

        dbContextMock
            .Verify(x => x
            .SaveChangesAsync(It
            .IsAny<CancellationToken>()), Times.Once);
    }
}
