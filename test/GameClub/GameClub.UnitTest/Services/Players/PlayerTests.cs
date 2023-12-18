using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.PlayerCases.Commands;
using GameClub.Application.UseCases.PlayerCases.Handlers.C;
using GameClub.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Shouldly;

namespace GameClub.UnitTest.Services.Players;

public class PlayerTests
{
    [Fact]
    public async ValueTask ShouldReturnTrueWhenPlayerCreateIsValid()
    {
        // Arrange
        var command = new PlayerCreateCommand
        {
            NickName = "nimadur",
            ComputerId = 1,
            HoursCount = 1,
        };

        var dbContextMock = new Mock<IApplicationDbContext>();
        var mapperMock = new Mock<IMapper>();

        var handler = new PlayerCreateCommandHandler(dbContextMock.Object, mapperMock.Object);

        // Mock the mapping
        mapperMock
            .Setup(x => x
            .Map<Player>(command))
            .Returns(new Player());

        dbContextMock.Setup(x => x
        .Players
        .AddAsync(It.IsAny<Player>(), It
        .IsAny<CancellationToken>()))
        .Returns(ValueTask
        .FromResult(Mock
        .Of<EntityEntry<Player>>(x => x
        .Entity == new Player())));

        dbContextMock
            .Setup(x => x
            .SaveChangesAsync(It
            .IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        result.ShouldBeOfType<Player>();

        result.ShouldBeTrue();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async ValueTask ShouldReturnTrueWhenPlayerUpdateIsValid()
    {
        // Arrange
        var command = new PlayerUpdateCommand
        {
            Id = 1,
            NickName = "Palonchi",
            HoursCount = 1,
        };

        var dbContextMock = new Mock<IApplicationDbContext>();
        var mapperMock = new Mock<IMapper>();

        var handler = new PlayerUpdateCommandHandler(dbContextMock.Object, mapperMock.Object);

        mapperMock.Setup(x => x
        .Map<Player>(command))
        .Returns(new Player());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert 
        Assert.True(result);

        mapperMock.Verify(x => x.Map<Player>(command), Times.Once);

        dbContextMock.Verify(x => x.Players.Update(It.IsAny<Player>()), Times.Once);

        dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async ValueTask ShouldReturnTrueWhenPlayerDeleteIsValid()
    {
        var dbContextMock = new Mock<IApplicationDbContext>();

        var command = new PlayerDeleteCommand
        {
            Id = 1,
        };

        var handler = new PlayerDeleteCommanHandler(dbContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result);

        dbContextMock
            .Verify(x => x
            .Players
            .FirstOrDefault(x => x
            .Id == command.Id), Times.Once);

        dbContextMock
            .Verify(x => x
            .SaveChangesAsync(It
            .IsAny<CancellationToken>()), Times.Once);
    }
}
