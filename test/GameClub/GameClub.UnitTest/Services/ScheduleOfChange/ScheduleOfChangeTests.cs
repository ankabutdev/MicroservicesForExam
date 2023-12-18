using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Commands;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Handlers;
using GameClub.Domain.Entities;
using GameClub.Domain.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Shouldly;

namespace GameClub.UnitTest.Services.ScheduleOfChange;

public class ScheduleOfChangeTests
{
    [Fact]
    public async ValueTask ShouldReturnTrueWhenScheduleOfChangeCreateIsValid()
    {
        // Arrange
        var command = new ScheduleOfChangesCreateCommand
        {
            AdminId = 1,
            Description = "Test",
            PlayerId = 1,
            Status = ChangesStatus.Started,
            TotalPrice = 1,
        };

        var dbContextMock = new Mock<IApplicationDbContext>();
        var mapperMock = new Mock<IMapper>();

        var handler = new ScheduleOfChangesCreateCommandHandler(dbContextMock.Object, mapperMock.Object);

        // Mock the mapping
        mapperMock
            .Setup(x => x
            .Map<ScheduleOfChanges>(command))
            .Returns(new ScheduleOfChanges());

        dbContextMock.Setup(x => x
        .ScheduleOfChanges
        .AddAsync(It.IsAny<ScheduleOfChanges>(), It
        .IsAny<CancellationToken>()))
        .Returns(ValueTask
        .FromResult(Mock
        .Of<EntityEntry<ScheduleOfChanges>>(x => x
        .Entity == new ScheduleOfChanges())));

        dbContextMock
            .Setup(x => x
            .SaveChangesAsync(It
            .IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        result.ShouldBeOfType<ScheduleOfChanges>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async ValueTask ShouldReturnTrueWhenScheduleOfChangeUpdateIsValid()
    {
        // Arrange
        var command = new ScheduleOfChangesUpdateCommand
        {
            Id = 1,
            AdminId = 1,
            Description = "Test",
            PlayerId = 1,
            Status = ChangesStatus.Playing,
            TotalPrice = 1,
        };

        var dbContextMock = new Mock<IApplicationDbContext>();
        var mapperMock = new Mock<IMapper>();

        var handler = new ScheduleOfChangesUpdateCommandHandler(dbContextMock.Object, mapperMock.Object);

        mapperMock.Setup(x => x
        .Map<ScheduleOfChanges>(command))
        .Returns(new ScheduleOfChanges());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert 
        Assert.True(result);

        mapperMock.Verify(x => x.Map<ScheduleOfChanges>(command), Times.Once);

        dbContextMock.Verify(x => x.ScheduleOfChanges.Update(It.IsAny<ScheduleOfChanges>()), Times.Once);

        dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async ValueTask ShouldReturnTrueWhenScheduleOfChangeDeleteIsValid()
    {
        var dbContextMock = new Mock<IApplicationDbContext>();

        var command = new ScheduleOfChangesDeleteCommand
        {
            Id = 1,
        };

        var handler = new ScheduleOfChangesDeleteCommandHandler(dbContextMock.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result);

        dbContextMock
            .Verify(x => x
            .ScheduleOfChanges
            .FirstOrDefault(x => x
            .Id == command.Id), Times.Once);

        dbContextMock
            .Verify(x => x
            .SaveChangesAsync(It
            .IsAny<CancellationToken>()), Times.Once);
    }
}
